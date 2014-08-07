using System.Collections.ObjectModel;

using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using Corporate.Domain.Entities;
using Corporate.Interfaces.Repositories;


namespace Corporate.Expenditures.ViewModels
{
    public class ReviewOfficeViewModel : BindableBase
    {
        private string _officeLocal;
        private IExpenseRepository _expenseRepository; 
        public ObservableCollection<CategoryViewModel> Categories { get; set; }
        public ObservableCollection<Expense> Expenses { get; set; }
        private DelegateCommand _mainPageCommand;
        private DelegateCommand _addNewExpenseCommand;

        public ReviewOfficeViewModel(){}
        
        public ReviewOfficeViewModel(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        public string OfficeLocal { get { return _officeLocal; } set { SetProperty(ref _officeLocal, value); } }

        public DelegateCommand MainPageCommand { get { return _mainPageCommand ?? (_mainPageCommand = new DelegateCommand(MainPage)); } }

        public DelegateCommand AddNewExpenseCommand { get { return _addNewExpenseCommand ?? (_addNewExpenseCommand = new DelegateCommand(AddNewExpense)); } }

        public void MainPage(){}

        public void AddNewExpense(){}
    }
}
