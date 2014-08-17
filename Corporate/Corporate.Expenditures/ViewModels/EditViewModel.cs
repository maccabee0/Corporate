using System;
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
    public class EditViewModel : BindableBase, IInteractionRequestAware
    {
        private DelegateCommand _saveCommand;
        private DelegateCommand _saveAddCommand;
        private DelegateCommand _cancelCommand;
        private EditExpenseNotification _notification;

        public EditViewModel() { }

        public DelegateCommand SaveCommand { get { return _saveCommand ?? (_saveCommand = new DelegateCommand(SaveAndClose)); } }
        public DelegateCommand SaveAddCommand { get { return _saveAddCommand ?? (_saveAddCommand = new DelegateCommand(Save)); } }
        public DelegateCommand CancelCommand { get { return _cancelCommand ?? (_cancelCommand = new DelegateCommand(Cancel)); } }
        public INotification Notification
        {
            get { return _notification; }
            set
            {
                if (value is EditExpenseNotification)
                {
                    _notification = value as EditExpenseNotification;
                    OnPropertyChanged(() => Notification);
                }
            }
        }
        public Action FinishInteraction { get; set; }

        private void Cancel()
        {
            if (_notification == null) return;
            _notification.Confirmed = false;
            FinishInteraction();
        }

        private void Save()
        {
            if (_notification == null) return;
            _notification.Confirmed = true;
            FinishInteraction();
        }

        private void SaveAndClose()
        {
            if (_notification == null) return;
            _notification.Confirmed = true;
            FinishInteraction();
        }

        //private bool CanSave()
        //{
        //    return (_notification.SelectedExpenseId != 0 && _notification.Amount != 0);
        //}
    }
}
