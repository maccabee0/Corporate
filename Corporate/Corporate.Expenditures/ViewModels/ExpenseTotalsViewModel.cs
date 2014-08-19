using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Corporate.Domain.Entities;

namespace Corporate.Expenditures.ViewModels
{
    public class ExpenseTotalsViewModel
    {
        ObservableCollection<CategoryViewModel> CategoryViewModels { get; set; }
        public decimal Total { get; set; }

        public ExpenseTotalsViewModel()
        {
            CategoryViewModels=new ObservableCollection<CategoryViewModel>();
        }

        public ExpenseTotalsViewModel(IEnumerable<Expense> expenses)
            :this()
        {
            Update(expenses);
        }

        public void Update(IEnumerable<Expense> expenses)
        {
            foreach (var expense in expenses)
            {
                var total = expense.Logs.Sum(l=>l.Amount);
                CategoryViewModels.Add(new CategoryViewModel(expense.Expenseid,expense.Name,total));
                Total += total;
            }
        }
    }
}
