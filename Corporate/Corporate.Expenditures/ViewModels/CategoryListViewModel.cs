using System;
using System.Collections.Generic;

using Corporate.Domain.Entities;

using Microsoft.Practices.Prism.Commands;

namespace Corporate.Expenditures.ViewModels
{
    public class CategoryListViewModel
    {
        public string Office { get; set; }
        public string Category { get; set; }
        public IEnumerable<Expense_Log> Logs { get; set; }
        private DelegateCommand _closeCommand;

        public CategoryListViewModel()
        {
            Office = "London";
            Category = "Other";
            Logs = new List<Expense_Log>
                {
                    new Expense_Log {Amount = 123, InputDate = DateTime.Now},
                    new Expense_Log {Amount = 546, InputDate = new DateTime(2014, 6, 14)},
                    new Expense_Log {Amount = 789, InputDate = new DateTime(2014, 7, 25)}
                };
        }

        public CategoryListViewModel(string office, string category, IEnumerable<Expense_Log> logs)
        {
            Office = office;
            Category = category;
            Logs = logs;
        }
        public DelegateCommand CloseCommand { get { return _closeCommand ?? (_closeCommand = new DelegateCommand(Close)); } }

        public void Close() { }
    }
}
