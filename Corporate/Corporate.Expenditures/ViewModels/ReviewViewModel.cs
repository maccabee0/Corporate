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

namespace Corporate.Expenditures.ViewModels
{
    public class ReviewViewModel : BindableBase
    {
        private IOfficeRepository _officeRepository;
        private DelegateCommand _mainPageCommand;
        private DelegateCommand _reviewByCategoryCommand;
        public ObservableCollection<OfficeTotalsViewModel> OfficeTotalsViewModels { get; set; }
        private ICollectionView _officeTotalsView;

        public ReviewViewModel()
        {
            var list = new List<Office> {};
        }

        public ReviewViewModel(IOfficeRepository repository)
        {
            _officeRepository = repository;
            var list = _officeRepository.GetOfficesBy(o => true).Select(office => new OfficeTotalsViewModel(office)).ToList();
            OfficeTotalsViewModels=new ObservableCollection<OfficeTotalsViewModel>(list);
            _officeTotalsView = new CollectionView(OfficeTotalsViewModels);
        }

        public ICollectionView OfficeTotalsView { get { return _officeTotalsView; } }
        public DelegateCommand MainPageCommand { get { return _mainPageCommand ?? (_mainPageCommand = new DelegateCommand(MainPage)); } }
        public DelegateCommand ReviewByCategoryCommand { get { return _reviewByCategoryCommand ?? (_reviewByCategoryCommand = new DelegateCommand(ReviewByCategory, CanReviewByCategory)); } }

        private void MainPage() { }

        private void ReviewByCategory() { }
        private bool CanReviewByCategory()
        {
            return true;
        }
    }
}
