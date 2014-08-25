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
        private DelegateCommand _mainPageCommand;
        private DelegateCommand _reviewByCategoryCommand;
        public ObservableCollection<RowViewModel> Rows { get; set; }
        public InteractionRequest<INotification> CategoryListRequest { get; set; }

        public ReviewViewModel(IOfficeRepository repository, IExpenseRepository expenseRepository)
        {
            var expenses = expenseRepository.GetExpencesBy(e => true);
            var offices = repository.GetOfficesBy(o => true);
            Rows = SetRows(offices, expenses);
            CategoryListRequest = new InteractionRequest<INotification>();
        }

        public DelegateCommand MainPageCommand { get { return _mainPageCommand ?? (_mainPageCommand = new DelegateCommand(MainPage)); } }
        public DelegateCommand ReviewByCategoryCommand { get { return _reviewByCategoryCommand ?? (_reviewByCategoryCommand = new DelegateCommand(ReviewByCategory)); } }

        private void MainPage()
        {
            if (_navigationJournal != null && _navigationJournal.CanGoBack)
            {
                _navigationJournal.GoBack();
            }
        }

        private void ReviewByCategory()
        {
            //var expense = new Expense { Expenseid = 1, Name = "Other" };
            //var listView = new CategoryListViewModel(CurrentOffice.Name, expense.Name, CurrentOffice.Logs.Where(l => l.Expenseid == expense.Expenseid));
            //CategoryListRequest.Raise(new Notification { Content = listView, Title = CurrentOffice.Name });
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            _navigationJournal = navigationContext.NavigationService.Journal;
            //OfficeTotalsView.Refresh();
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
        }

        public bool KeepAlive { get { return true; } }

        private ObservableCollection<RowViewModel> SetRows(IEnumerable<Office> offices, IEnumerable<Expense> expenses)
        {
            var rows = new ObservableCollection<RowViewModel>();
            var exp = expenses.OrderBy(e => e.Expenseid).ToList();
            foreach (var office in offices)
            {
                RowViewModel row = new RowViewModel();
                row.Columns.Add(new ColumnViewModel("Office",new TotalsCellViewModel(office.Officeid,0,office.Name)));
                foreach (var expense in exp)
                {
                    var total = expense.Logs.Where(l => l.Officeid == office.Officeid).Sum(l => l.Amount);
                    row.Columns.Add(new ColumnViewModel(expense.Name, new TotalsCellViewModel(office.Officeid, expense.Expenseid, total.ToString())));
                }
                row.Columns.Add(new ColumnViewModel("Total", new TotalsCellViewModel(office.Officeid,0,office.Logs.Sum(l => l.Amount).ToString())));
                rows.Add(row);
            }
            return rows;
        }

        public void OnMouseItemSelected(object sender, ItemSelectedEventArgs e)
        {
            var item = e.Item;
        }
    }
}
