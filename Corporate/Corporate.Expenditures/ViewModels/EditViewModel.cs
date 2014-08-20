using System;

using Corporate.Expenditures.Notifications;

using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Interactivity.InteractionRequest;
using Microsoft.Practices.Prism.Mvvm;

namespace Corporate.Expenditures.ViewModels
{
    public class EditViewModel : BindableBase, IInteractionRequestAware
    {
        private DelegateCommand _saveCommand;
        private DelegateCommand _cancelCommand;
        private EditExpenseNotification _notification;

        public EditViewModel() { }

        public DelegateCommand SaveCommand { get { return _saveCommand ?? (_saveCommand = new DelegateCommand(SaveAndClose)); } }
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

        private void SaveAndClose()
        {
            if (_notification == null) return;
            _notification.Confirmed = true;
            FinishInteraction();
        }
    }
}
