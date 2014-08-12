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

        public OfficeTotalsViewModel()
            : this(new Office
                {
                    Name = "London",
                    Officeid = 1,
                    Logs = new Collection<Expense_Log>
                        {
                            new Expense_Log{Amount = 20,Expenseid = 1,Expense = new Expense{Expenseid = 1,Name = "Coffee/Tea"},InputDate = DateTime.Now},
                    new Expense_Log{Amount = 140,Expenseid = 2,Expense = new Expense{Expenseid = 2,Name = "Internet"},InputDate = DateTime.Now},
                    new Expense_Log{Amount = 500,Expenseid = 3,Expense = new Expense{Expenseid = 3,Name = "Other"},InputDate = DateTime.Now}
                        }
                }) { }

        public OfficeTotalsViewModel(Office office)
        {
            OfficeLocal = office.Name;
            SetUpCategories(office);
            _categoryView=new CollectionView(_categoryViewModels);
        }

        public string OfficeLocal { get { return _officeLocal; } set { SetProperty(ref _officeLocal, value); } }
        public ObservableCollection<CategoryViewModel> CategoryViewModels { get { return _categoryViewModels; } }
        public ICollectionView CategoryView { get { return _categoryView; } }

        private void SetUpCategories(Office office)
        {
            foreach (var log in office.Logs)
            {
                if (CategoryViewModels.All(c => c.Id != log.Expenseid))
                {
                    CategoryViewModels.Add(new CategoryViewModel(log.Expenseid, log.Expense.Name, log.Amount));
                }
                else
                {
                    var cat = CategoryViewModels.FirstOrDefault(c => c.Id == log.Expenseid);
                    if (cat != null) cat.Total += log.Amount;
                }
            }
        }
    }
}
