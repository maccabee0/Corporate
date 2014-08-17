using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using Corporate.Domain;
using Corporate.Domain.Entities;
using Corporate.Interfaces.Repositories;

using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace Corporate.Expenditures.ViewModels
{
    public class MainViewModel : BindableBase, IRegionMemberLifetime,INavigationAware
    {
        //[Dependency]
        private IOfficeRepository _officeRepository { get; set; }
        public ObservableCollection<Office> Offices { get; set; }
        private ICollectionView _officesView;
        private DelegateCommand _reviewAllCommand;
        private DelegateCommand _reviewOfficeCommand;
        private IRegionManager _regionManager;

        //public MainViewModel()
        //{
        //    var list = new List<Office>
        //        {
        //            new Office { Officeid = 1, Name = "London" }, 
        //            new Office { Officeid = 2, Name = "New York" }, 
        //            new Office { Officeid = 3, Name = "Kyiv" }
        //        };
        //    Offices = new ObservableCollection<Office>(list);
        //    _officesView = new CollectionView(Offices);
        //    //_officesView.MoveCurrentToFirst(); 
        //    _officesView.CurrentChanged += OnCurrentOfficeChanged;
        //}

        public MainViewModel(IOfficeRepository officeRepository, IRegionManager regionManager)
        {
            _officeRepository = officeRepository;
            Offices = new ObservableCollection<Office>(_officeRepository.GetOfficesBy(o => true));
            _officesView = new CollectionView(Offices);
            _officesView.CurrentChanged += OnCurrentOfficeChanged;
            _regionManager = regionManager;
        }

        public ICollectionView OfficesView { get { return _officesView; } }
        public Office CurrentOffice { get { return _officesView.CurrentItem as Office; } }
        public DelegateCommand ReviewAllCommand { get { return _reviewAllCommand ?? (_reviewAllCommand = new DelegateCommand(ReviewAll)); } }
        public DelegateCommand ReviewOfficeCommand { get { return _reviewOfficeCommand ?? (_reviewOfficeCommand = new DelegateCommand(ReviewOffice, CanReviewOffice)); } }


        public void ReviewAll()
        {
            _regionManager.RequestNavigate(RegionNames.MainRegion, new Uri(ExpenditureKeys.ReviewView, UriKind.Relative));
        }

        public void ReviewOffice()
        {
            NavigationParameters parameters = new NavigationParameters();
            var office = CurrentOffice;
            parameters.Add(ExpenditureKeys.OfficeId, office.Officeid);
            parameters.Add(ExpenditureKeys.OfficeLocal, office.Name);
            _regionManager.RequestNavigate(RegionNames.MainRegion, new Uri(ExpenditureKeys.ReviewOfficeView + parameters, UriKind.Relative));
        }

        public bool CanReviewOffice()
        {
            return CurrentOffice != null;
        }

        private void OnCurrentOfficeChanged(object sender, EventArgs e)
        {
            OnPropertyChanged(() => CurrentOffice);
            ReviewOfficeCommand.RaiseCanExecuteChanged();
        }

        public bool KeepAlive
        {
            get { return true; }
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
            //throw new NotImplementedException();
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
        }
    }
}
