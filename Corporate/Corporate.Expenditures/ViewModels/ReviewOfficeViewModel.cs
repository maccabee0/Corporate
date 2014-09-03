using System;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Data;

using Corporate.Expenditures.Notifications;

using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Interactivity.InteractionRequest;
using Microsoft.Practices.Prism.Mvvm;
using Corporate.Domain.Entities;
using Corporate.Interfaces.Repositories;
using Microsoft.Practices.Prism.Regions;


namespace Corporate.Expenditures.ViewModels
{
    public class ReviewOfficeViewModel : BindableBase, INavigationAware, IRegionMemberLifetime
    {
        private int _officeId;
        private string _officeLocal;
        private decimal _officeTotal;
        private IExpenseRepository _expenseRepository;
        private IExpenseLogRepository _expenseLogRepository;
        private IRegionNavigationJournal _navigationJournal;
        public ObservableCollection<CategoryViewModel> Categories { get; set; }
        public ObservableCollection<Expense_Log> ExpenseLogs { get; set; }
        private ICollectionView _expenseLogView;
        private DelegateCommand _mainPageCommand;
        private DelegateCommand _addNewExpenseCommand;
        private DelegateCommand _editExpenseCommand;

        public ReviewOfficeViewModel(IExpenseRepository expenseRepository, IExpenseLogRepository expenseLogRepository)
        {
            _expenseRepository = expenseRepository;
            _expenseLogRepository = expenseLogRepository;
            ExpenseLogs = new ObservableCollection<Expense_Log>();
            _expenseLogView = new CollectionView(ExpenseLogs);
            EditExpenseRequest = new InteractionRequest<EditExpenseNotification>();
            Categories = new ObservableCollection<CategoryViewModel>();
        }

        public string OfficeLocal { get { return _officeLocal; } set { SetProperty(ref _officeLocal, value); } }
        public decimal OfficeTotal { get { return _officeTotal; } set { SetProperty(ref _officeTotal, value); } }
        public ICollectionView ExpenseLogView { get { return _expenseLogView; } }
        public Expense_Log CurrentExpense { get { return _expenseLogView.CurrentItem as Expense_Log; } }
        //Commands
        public DelegateCommand MainPageCommand { get { return _mainPageCommand ?? (_mainPageCommand = new DelegateCommand(MainPage)); } }
        public DelegateCommand AddNewExpenseCommand { get { return _addNewExpenseCommand ?? (_addNewExpenseCommand = new DelegateCommand(AddNewExpense)); } }
        public DelegateCommand EditExpenseCommand { get { return _editExpenseCommand ?? (_editExpenseCommand = new DelegateCommand(EditExpense, CanEditExpense)); } }
        //InteractionRequests
        public InteractionRequest<EditExpenseNotification> EditExpenseRequest { get; private set; }

        private void MainPage()
        {
            if (_navigationJournal != null && _navigationJournal.CanGoBack)
            {
                _navigationJournal.GoBack();
            }
        }

        private void AddExpenseToLists(Expense_Log expense)
        {
            ExpenseLogs.Insert(0, expense);
            var categoryViewModel = Categories.FirstOrDefault(c => c.Id == expense.Expenseid);
            if (categoryViewModel != null)
                categoryViewModel.Total += expense.Amount;
            ExpenseLogView.Refresh();
        }

        private void AddNewExpense()
        {
            var notification = new EditExpenseNotification(_officeId, OfficeLocal)
                                   {
                                       Expenses =
                                           _expenseRepository
                                           .GetExpencesBy(e => true)
                                   };
            EditExpenseRequest.Raise(notification,
                returned =>
                {
                    if (returned == null || !returned.Confirmed || returned.Amount == 0 ||
                        returned.SelectedExpenseId == 0) return;
                    var expense = CreateExpenseLog(returned);
                    _expenseLogRepository.SaveLog(expense);
                    AddExpenseToLists(expense);
                });
        }

        private bool CanEditExpense()
        {
            return CurrentExpense != null;
        }

        private Expense_Log CreateExpenseLog(EditExpenseNotification returned)
        {
            return new Expense_Log
            {
                Amount = returned.Amount,
                Description = returned.Note,
                Expenseid = returned.SelectedExpenseId,
                ExpenseLogId = returned.LogId,
                InputDate = DateTime.Now,
                Officeid = returned.OfficeId
            };
        }

        void GetOfficeExpenseLogs(int id, string officeLocal)
        {
            _officeId = id;
            OfficeLocal = officeLocal;
            var logs = _expenseLogRepository.GetLogsByOffice(id);
            ExpenseLogs = new ObservableCollection<Expense_Log>(logs);
            var cats = _expenseRepository.Expenses.Select(e => new CategoryViewModel
            {
                Id = e.Expenseid,
                Category = e.Name,
                Total = logs.Any(l => l.Expenseid == e.Expenseid && l.Officeid == _officeId) ? logs.Where(l => l.Expenseid == e.Expenseid && l.Officeid == _officeId).Sum(l => l.Amount) : 0
            }).ToList();
            Categories = new ObservableCollection<CategoryViewModel>(cats);
            OfficeTotal = logs.Sum(l => l.Amount);
        }

        private void EditExpense()
        {
            var notification = new EditExpenseNotification(CurrentExpense)
                {
                    Expenses = _expenseRepository.GetExpencesBy(e => true)
                };
            EditExpenseRequest.Raise(notification,
                returned =>
                {
                    if (returned == null || !returned.Confirmed || returned.Amount == 0 ||
                        returned.SelectedExpenseId == 0) return;
                    var expense = CreateExpenseLog(returned);
                    _expenseLogRepository.SaveLog(expense);
                    AddExpenseToLists(expense);
                });
        }

        #region Navigation
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            var id = int.Parse(navigationContext.Parameters[ExpenditureKeys.OfficeId].ToString());
            var local = navigationContext.Parameters[ExpenditureKeys.OfficeLocal] as string;
            GetOfficeExpenseLogs(id, local);
            _navigationJournal = navigationContext.NavigationService.Journal;
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            var id = int.Parse(navigationContext.Parameters[ExpenditureKeys.OfficeId].ToString());
            return id == _officeId || _officeId == 0;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }
        #endregion

        public bool KeepAlive
        {
            get { return true; }
        }
    }
}
