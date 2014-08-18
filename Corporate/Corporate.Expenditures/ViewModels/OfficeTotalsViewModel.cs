using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ComponentModel;
using System.Windows.Data;
using Microsoft.Practices.Prism.Mvvm;

using Corporate.Domain.Entities;


namespace Corporate.Expenditures.ViewModels
{
    public class OfficeTotalsViewModel : BindableBase
    {
        public int Id;
        private string _officeLocal;
        private ObservableCollection<CategoryViewModel> _categoryViewModels;
        private ICollectionView _categoryView;
        
        public OfficeTotalsViewModel(Office office, IEnumerable<Expense> expenses)
        {
            OfficeLocal = office.Name;
            CategoryViewModels=new ObservableCollection<CategoryViewModel>();
            SetUpCategories(office, expenses);
            _categoryView=new CollectionView(_categoryViewModels);
        }

        public string OfficeLocal { get { return _officeLocal; } set { SetProperty(ref _officeLocal, value); } }
        public ObservableCollection<CategoryViewModel> CategoryViewModels { get { return _categoryViewModels; } set { SetProperty(ref _categoryViewModels, value); } }
        public ICollectionView CategoryView { get { return _categoryView; } }

        private void SetUpCategories(Office office, IEnumerable<Expense> expenses)
        {
            foreach (var expense in expenses)
            {
                CategoryViewModels.Add(new CategoryViewModel(expense.Expenseid, expense.Name,
                                                office.Logs.Where(l => l.Expenseid == expense.Expenseid)
                                                      .Sum(l => l.Amount)));
            }
            
        }
    }
}
