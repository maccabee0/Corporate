using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

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
        private DelegateCommand _reviewByCategoryCommand;
        //public ObservableCollection<Expense_Log> _logs { get; set; }
        private ICollectionView _officeTotalsView;

        public ReviewViewModel()
        {
            var list = new List<Office> {};
        }

        public ReviewViewModel(IExpenseLogRepository repository)
        {
            _logRepository = repository;
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
