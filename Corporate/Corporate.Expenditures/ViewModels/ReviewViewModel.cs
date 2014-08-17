using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;

using Corporate.Domain.Entities;
using Corporate.Interfaces.Repositories;

using Microsoft.Practices.Prism.Commands;
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
        private ICollectionView _officeTotalsView;

        public ReviewViewModel()
        {
            var list = new List<Office> { };
        }

        public ReviewViewModel(IOfficeRepository repository)
        {
            _officeRepository = repository;
            var list = _officeRepository.GetOfficesBy(o => true).Select(office => new OfficeTotalsViewModel(office)).ToList();
            OfficeTotalsViewModels = new ObservableCollection<OfficeTotalsViewModel>(list);
        }

        public ICollectionView OfficeTotalsView { get { return _officeTotalsView; } }
        public DelegateCommand MainPageCommand { get { return _mainPageCommand ?? (_mainPageCommand = new DelegateCommand(MainPage)); } }
        public DelegateCommand ReviewByCategoryCommand { get { return _reviewByCategoryCommand ?? (_reviewByCategoryCommand = new DelegateCommand(ReviewByCategory)); } }

        private void MainPage()
        {
            if (_navigationJournal != null && _navigationJournal.CanGoBack)
            {
                _navigationJournal.GoBack();
            }
        }

        private void ReviewByCategory() { }

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
            //throw new NotImplementedException();
        }

        public bool KeepAlive { get { return false; } }
    }
}
