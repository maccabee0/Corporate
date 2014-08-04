﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Corporate.Domain.Entities;
using Corporate.Interfaces.Repositories;

using Microsoft.Practices.Prism.Mvvm;

namespace Corporate.Expenditures.ViewModels
{
    public class EditViewModel:BindableBase
    {
        private IExpenseRepository _repository;
        private string _office;
        private IEnumerable<Expense> _expenses;
        private int _selectedExpense;
        private decimal _amount;
        private string _note;

        public EditViewModel(IExpenseRepository repository)
        {
            _repository = repository;
        }

        public string Office { get { return _office; } set { SetProperty(ref _office, value); } }
        public int SelectedExpense { get { return _selectedExpense; } set { SetProperty(ref _selectedExpense, value); } }
        public IEnumerable<Expense> Expenses { get { return _expenses; } set { SetProperty(ref _expenses, value); } }
        public decimal Amount { get { return _amount; } set { SetProperty(ref _amount, value); } }
        public string Note { get { return _note; } set { SetProperty(ref _note, value); } }
    }
}
