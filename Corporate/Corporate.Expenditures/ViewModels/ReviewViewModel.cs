using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Windows.Data;
using System.Windows.Input;

using Corporate.Domain.Entities;
using Corporate.Expenditures.CorporateEventArgs;
using Corporate.Interfaces.Repositories;

using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Interactivity.InteractionRequest;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.Regions;

namespace Corporate.Expenditures.ViewModels
{
    public class ReviewViewModel : BindableBase, INavigationAware, IRegionMemberLifetime
    {
        private IRegionNavigationJournal _navigationJournal;
        private IOfficeRepository _officeRepository;
        private DelegateCommand _mainPageCommand;
        private DelegateCommand<TotalsCellViewModel> _reviewByCategoryCommand;
        public ObservableCollection<RowViewModel> Rows { get; set; }
        public InteractionRequest<INotification> CategoryListRequest { get; set; }
        public InteractionRequest<INotification> ExpensesNotFoundRequest { get; set; }

        public ReviewViewModel(IOfficeRepository repository, IExpenseRepository expenseRepository)
        {
            _officeRepository = repository;
            var expenses = expenseRepository.GetExpencesBy(e => true);
            var offices = _officeRepository.GetOfficesBy(o => true);
            Rows = SetRows(offices, expenses);
            CategoryListRequest = new InteractionRequest<INotification>();
            ExpensesNotFoundRequest = new InteractionRequest<INotification>();
        }

        public DelegateCommand MainPageCommand
        {
            get { return _mainPageCommand ?? (_mainPageCommand = new DelegateCommand(MainPage)); }
        }

        public ICommand ReviewByCategoryCommand
        {
            get { return _reviewByCategoryCommand ?? (_reviewByCategoryCommand = new DelegateCommand<TotalsCellViewModel>(ReviewByCategory,CanReviewByCategory)); }
        }

        public bool KeepAlive { get { return false; } }

        private void MainPage()
        {
            if (_navigationJournal != null && _navigationJournal.CanGoBack)
            {
                _navigationJournal.GoBack();
            }
        }

        private bool CanReviewByCategory(TotalsCellViewModel viewModel)
        {
            return viewModel.ExpenseId != 0 && viewModel.OfficeId != 0 && viewModel.Text != "0";
        }

        private void ReviewByCategory(TotalsCellViewModel viewModel)
        {
            if (viewModel.OfficeId != 0)
            {
                var office = _officeRepository.GetOfficeById(viewModel.OfficeId);
                if (office.Logs.Any(l => l.Expenseid == viewModel.ExpenseId))
                {
                    var expense = office.Logs.FirstOrDefault(l => l.Expenseid == viewModel.ExpenseId).Expense;
                    var listView = new CategoryListViewModel(office.Name, expense.Name, office.Logs.Where(l => l.Expenseid == expense.Expenseid));
                    CategoryListRequest.Raise(new Notification { Content = listView, Title = office.Name });
                }
                else
                {
                    RaiseNotification(string.Format("No Expenses of the select type where found for {0}.", office.Name));
                }
            }
        }

        private void RaiseNotification(string message) 
        {
            this.ExpensesNotFoundRequest.Raise(
               new Notification { Content = message, Title = "Notification" },
               n => {  });
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            _navigationJournal = navigationContext.NavigationService.Journal;
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        private ObservableCollection<RowViewModel> SetRows(IEnumerable<Office> offices, IEnumerable<Expense> expenses)
        {
            var rows = new ObservableCollection<RowViewModel>();
            var exp = expenses.OrderBy(e => e.Expenseid).ToList();
            RowViewModel row;
            foreach (var office in offices)
            {
                row = new RowViewModel();
                row.Columns.Add(new ColumnViewModel("Office", office.Name));
                foreach (var expense in exp)
                {
                    var total = expense.Logs.Where(l => l.Officeid == office.Officeid).Sum(l => l.Amount);
                    row.Columns.Add(new ColumnViewModel(expense.Name, new TotalsCellViewModel(office.Officeid, expense.Expenseid, total.ToString())));
                }
                row.Columns.Add(new ColumnViewModel("Total", office.Logs.Sum(l => l.Amount)));
                rows.Add(row);
            }
            row = new RowViewModel();
            row.Columns.Add(new ColumnViewModel("Office", "Totals"));
            foreach (var expense in exp)
            {
                row.Columns.Add(new ColumnViewModel(expense.Name, new TotalsCellViewModel(0, expense.Expenseid, expense.Logs.Where(l => l.Expenseid == expense.Expenseid).Sum(l => l.Amount).ToString())));
            }
            row.Columns.Add(new ColumnViewModel("Total", exp.Sum(e => e.Logs.Sum(l => l.Amount))));
            rows.Add(row);
            return rows;
        }
    }
}
