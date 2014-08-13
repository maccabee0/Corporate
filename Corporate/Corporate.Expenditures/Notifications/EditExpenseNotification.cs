using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Corporate.Domain.Entities;

using Microsoft.Practices.Prism.Interactivity.InteractionRequest;

namespace Corporate.Expenditures.Notifications
{
    public class EditExpenseNotification:Confirmation
    {
        public Expense_Log ExpenseLog { get; set; }

        public EditExpenseNotification(){ExpenseLog=new Expense_Log();}
        public EditExpenseNotification(Expense_Log log)
        {
            ExpenseLog = log;
        }
    }
}
