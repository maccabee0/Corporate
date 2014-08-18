using System;
using System.ComponentModel.DataAnnotations;

namespace Corporate.Domain.Entities
{
    public class Expense_Log
    {
        [Key]
        public int ExpenseLogId { get; set; }
        public DateTime InputDate { get; set; }
        public int Expenseid { get; set; }
        public int Officeid { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }

        public virtual Office Office { get; set; }
        public virtual Expense Expense { get; set; }
    }
}
