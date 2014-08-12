using System;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Data;

using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using Corporate.Domain.Entities;
using Corporate.Interfaces.Repositories;


namespace Corporate.Expenditures.ViewModels
{
    public class ReviewOfficeViewModel : BindableBase
    {
        private string _officeLocal;
        private decimal _officeTotal;
        private IExpenseRepository _expenseRepository;
        public ObservableCollection<CategoryViewModel> Categories { get; set; }
        public ObservableCollection<Expense_Log> ExpenseLogs { get; set; }
        private ICollectionView _expenseLogView;
        private DelegateCommand _mainPageCommand;
        private DelegateCommand _addNewExpenseCommand;
        private DelegateCommand _editExpenseCommand;

        public ReviewOfficeViewModel()
        {
            var list = new List<Expense_Log>
                {
                    new Expense_Log{Amount = 20,Expenseid = 1,Expense = new Expense{Expenseid = 1,Name = "Coffee/Tea"},InputDate = DateTime.Now},
                    new Expense_Log{Amount = 140,Expenseid = 2,Expense = new Expense{Expenseid = 2,Name = "Internet"},InputDate = DateTime.Now},
                    new Expense_Log{Amount = 500,Expenseid = 3,Expense = new Expense{Expenseid = 3,Name = "Other"},InputDate = DateTime.Now}
                };
            OfficeLocal = "London";
            Categories = new ObservableCollection<CategoryViewModel>();
            foreach (var expenseLog in list)
            {
                if (Categories.All(c => c.Id != expenseLog.Expenseid))
                {
                    Categories.Add(new CategoryViewModel(expenseLog.Expenseid, expenseLog.Expense.Name,
                                                         expenseLog.Amount));
                }
                else
                {
                    var categoryViewModel = Categories.FirstOrDefault(c => c.Id == expenseLog.Expenseid);
                    if (categoryViewModel != null)
                        categoryViewModel.Total += expenseLog.Amount;
                }
            }
            ExpenseLogs = new ObservableCollection<Expense_Log>(list);
            _expenseLogView=new CollectionView(ExpenseLogs);
            OfficeTotal = list.Sum(e => e.Amount);
        }

        public ReviewOfficeViewModel(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        public string OfficeLocal { get { return _officeLocal; } set { SetProperty(ref _officeLocal, value); } }
        public decimal OfficeTotal { get { return _officeTotal; } set { SetProperty(ref _officeTotal, value); } }
        public ICollectionView ExpenseLogView { get { return _expenseLogView; } }
        public Expense_Log CurrentExpense { get { return _expenseLogView.CurrentItem as Expense_Log; } }

        public DelegateCommand MainPageCommand { get { return _mainPageCommand ?? (_mainPageCommand = new DelegateCommand(MainPage)); } }

        public DelegateCommand AddNewExpenseCommand { get { return _addNewExpenseCommand ?? (_addNewExpenseCommand = new DelegateCommand(AddNewExpense)); } }

        public DelegateCommand EditExpenseCommand { get { return _editExpenseCommand ?? (_editExpenseCommand = new DelegateCommand(EditExpense, CanEditExpense)); } }

        private void MainPage() { }

        private void AddNewExpense() { }

        private void EditExpense() { }

        private bool CanEditExpense()
        {
            return CurrentExpense != null;
        }
    }
}
