using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Corporate.Domain.Entities;

using Microsoft.Practices.Prism.Interactivity.InteractionRequest;

namespace Corporate.Expenditures.Notifications
{
    public class EditExpenseNotification : Confirmation
    {
        public EditExpenseNotification(int officeId,string officeLocal)
        {
            Title = "New";
            OfficeLocal = officeLocal;
            OfficeId = officeId;
        }
        public EditExpenseNotification(Expense_Log log)
        {
            Title = "Edit";
            OfficeId = log.Officeid;
            OfficeLocal = log.Office.Name;
            Amount = log.Amount;
            Note = log.Description;
            SelectedExpenseId = log.Expenseid;
            LogId = log.ExpenseLogId;
        }

        public IEnumerable<Expense> Expenses { get; set; }

        public int OfficeId { get; set; }
        public string OfficeLocal { get; set; }
        public decimal Amount { get; set; }
        public int SelectedExpenseId { get; set; }
        public string Note { get; set; }
        public int LogId { get; set; }
    }
}
