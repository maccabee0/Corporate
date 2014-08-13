﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Corporate.Expenditures.Notifications;

using Microsoft.Practices.Prism.Commands;

using Corporate.Domain.Entities;
using Corporate.Interfaces.Repositories;

using Microsoft.Practices.Prism.Interactivity.InteractionRequest;
using Microsoft.Practices.Prism.Mvvm;

namespace Corporate.Expenditures.ViewModels
{
    public class EditViewModel:BindableBase, IInteractionRequestAware
    {
        private IExpenseRepository _repository;
        private string _office;
        private int _officeId;
        private IEnumerable<Expense> _expenses;
        private int _selectedExpense;
        private decimal _amount;
        private string _note;
        private DelegateCommand _saveCommand;
        private DelegateCommand _saveAddCommand;
        private DelegateCommand _cancelCommand;
        private EditExpenseNotification _notification;

        public EditViewModel(){}

        public EditViewModel(IExpenseRepository repository)
        {
            _repository = repository;
        }

        public string Office { get { return _office; } set { SetProperty(ref _office, value); } }
        public int SelectedExpense { get { return _selectedExpense; } set { SetProperty(ref _selectedExpense, value); } }
        public IEnumerable<Expense> Expenses { get { return _expenses; } set { SetProperty(ref _expenses, value); } }
        public decimal Amount { get { return _amount; } set { SetProperty(ref _amount, value); } }
        public string Note { get { return _note; } set { SetProperty(ref _note, value); } }
        public DelegateCommand SaveCommand { get { return _saveCommand ?? (_saveCommand = new DelegateCommand(SaveAndClose, CanSave)); } }
        public DelegateCommand SaveAddCommand { get { return _saveAddCommand ?? (_saveAddCommand = new DelegateCommand(Save, CanSave)); } }
        public DelegateCommand CancelCommand { get { return _cancelCommand ?? (_cancelCommand = new DelegateCommand(Cancel)); } }

        private void Cancel()
        {
            if (_notification == null) return;
            _notification.ExpenseLog = null;
            _notification.Confirmed = false;
            FinishInteraction();
        }

        private void Save()
        {
            if (_notification == null) return;
            _notification.ExpenseLog = new Expense_Log
                {
                    Amount = Amount,
                    Officeid = _officeId,
                    Description = Note,
                    InputDate = DateTime.Now,
                    Expenseid = SelectedExpense
                };
            _notification.Confirmed = true;
            FinishInteraction();
        }

        private void SaveAndClose()
        {
            if (_notification == null) return;
            _notification.ExpenseLog = new Expense_Log
            {
                Amount = Amount,
                Officeid = _officeId,
                Description = Note,
                InputDate = DateTime.Now,
                Expenseid = SelectedExpense
            };
            _notification.Confirmed = true;
            FinishInteraction();
        }

        private bool CanSave()
        {
            return (_selectedExpense != 0 && _amount != 0);
        }

        public INotification Notification
        {
            get { return _notification; } 
            set{
                if(value is EditExpenseNotification)
                {
                    _notification = value as EditExpenseNotification;
                    OnPropertyChanged(()=>Notification);
                }
            }
        }
        public Action FinishInteraction { get; set; }
    }
}
