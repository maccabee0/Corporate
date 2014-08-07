using System;
using System.Collections.ObjectModel;

using Corporate.Domain.Entities;
using Corporate.Interfaces.Repositories;

using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;

namespace Corporate.Expenditures.ViewModels
{
    public class ReviewViewModel : BindableBase
    {
        private IExpenseLogRepository _logRepository;
        private DelegateCommand _mainPageCommand;
        public ObservableCollection<Expense_Log> _logs { get; set; }

        public ReviewViewModel() { }

        public ReviewViewModel(IExpenseLogRepository repository)
        {
            _logRepository = repository;
        }

        public DelegateCommand MainPageCommand { get { return _mainPageCommand ?? (_mainPageCommand = new DelegateCommand(MainPage)); } }

        private void MainPage() { }
    }
}
