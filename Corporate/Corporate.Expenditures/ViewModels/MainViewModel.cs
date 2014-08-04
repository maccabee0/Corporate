using System.Collections.ObjectModel;

using Corporate.Domain.Entities;
using Corporate.Interfaces.Repositories;

using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;

namespace Corporate.Expenditures.ViewModels
{
    public class MainViewModel:BindableBase
    {
        private IOfficeRepository _officeRepository;
        public ObservableCollection<Office> Offices { get; set; }
        private int _selectedOffice;
        private DelegateCommand _reviewAll;
        private DelegateCommand<int> _reviewOffice;

        public MainViewModel(IOfficeRepository officeRepository)
        {
            _officeRepository = officeRepository;
            Offices = new ObservableCollection<Office>(officeRepository.GetOfficesBy(o => true));
        }

        public DelegateCommand ReviewAllCommand { get { return _reviewAll ?? (_reviewAll = new DelegateCommand(ReviewAll)); } }
        public DelegateCommand<int> ReviewOfficeCommand { get { return _reviewOffice ?? (_reviewOffice = new DelegateCommand<int>(ReviewOffice, CanReviewOffice)); } }

        public int SelectedOffice { get { return _selectedOffice; } set { SetProperty(ref _selectedOffice,value); } }

        public void ReviewAll()
        {

        }

        public void ReviewOffice(int officeId)
        {

        }

        public bool CanReviewOffice(int officeId)
        {
            return officeId != 0;
        }
    }
}
