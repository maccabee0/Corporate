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

        public CategoryListViewModel(string office, string category, IEnumerable<Expense_Log> logs)
        {
            Office = office;
            Category = category;
            Logs = logs;
        }
        public DelegateCommand CloseCommand { get { return _closeCommand ?? (_closeCommand = new DelegateCommand(Close)); } }

        public void Close(){}
    }
}
