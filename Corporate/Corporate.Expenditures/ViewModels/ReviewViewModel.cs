using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;

using Corporate.Domain.Entities;
using Corporate.Interfaces.Repositories;

using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Interactivity.InteractionRequest;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.Regions;

namespace Corporate.Expenditures.ViewModels
{
    public class ReviewViewModel : BindableBase, INavigationAware, IRegionMemberLifetime
    {
        private IOfficeRepository _officeRepository;
        private IRegionNavigationJournal _navigationJournal;
        private DelegateCommand _mainPageCommand;
        private DelegateCommand _reviewByCategoryCommand;
        public ObservableCollection<OfficeTotalsViewModel> OfficeTotalsViewModels { get; set; }
        public InteractionRequest<INotification> CategoryListRequest { get; set; }
        private ICollectionView _officeTotalsView;

        public ReviewViewModel()
        {
            var list = new List<Office> { };
        }

        public ReviewViewModel(IOfficeRepository repository, IEnumerable<Expense> expenses)
        {
            _officeRepository = repository;
            var list = _officeRepository.GetOfficesBy(o => true).Select(office => new OfficeTotalsViewModel(office, expenses)).ToList();
            OfficeTotalsViewModels = new ObservableCollection<OfficeTotalsViewModel>(list);
            OfficeTotalsView.Refresh();
            CategoryListRequest = new InteractionRequest<INotification>();
        }

        public Office CurrentOffice { get { return OfficeTotalsView.CurrentItem as Office; } }
        public ICollectionView OfficeTotalsView { get { return new CollectionView(OfficeTotalsViewModels); } }
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
            var expense = new Expense { Expenseid = 1, Name = "Other" };
            var listView = new CategoryListViewModel(CurrentOffice.Name, expense.Name, CurrentOffice.Logs.Where(l => l.Expenseid == expense.Expenseid));
            CategoryListRequest.Raise(new Notification { Content = listView, Title = CurrentOffice.Name });
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            _navigationJournal = navigationContext.NavigationService.Journal;
            OfficeTotalsView.Refresh();
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
    }
}
