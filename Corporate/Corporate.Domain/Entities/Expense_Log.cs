using System;

namespace Corporate.Domain.Entities
{
    public class Expense_Log
    {
        public int ExpenseLogId { get; set; }
        public DateTime InputDate { get; set; }
        public int Expenseid { get; set; }
        public int Officeid { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }

        public Office Office { get; set; }
        public Expense Expense { get; set; }
    }
}
