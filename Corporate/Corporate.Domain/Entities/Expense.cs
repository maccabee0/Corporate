using System.Collections.Generic;

namespace Corporate.Domain.Entities
{
    public class Expense
    {
        public int Expenseid { get; set; }
        public int Name { get; set; }
        public ICollection<Expense_Log> Logs { get; set; }
    }
}
