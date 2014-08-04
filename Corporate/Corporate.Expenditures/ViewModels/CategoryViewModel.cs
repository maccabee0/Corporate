using Microsoft.Practices.Prism.Mvvm;

namespace Corporate.Expenditures.ViewModels
{
    public class CategoryViewModel:BindableBase
    {
        private string _category;
        private decimal _total;

        public CategoryViewModel(string category, decimal total)
        {
            Category = category;
            Total = total;
        }

        public string Category { get { return _category; } set { SetProperty( ref _category, value); } }
        public decimal Total { get { return _total; } set { SetProperty(ref _total, value); } }
    }
}
