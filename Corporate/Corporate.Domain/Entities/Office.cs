using System.Collections.Generic;

namespace Corporate.Domain.Entities
{
    public class Office
    {
        public int Officeid { get; set; }
        public string Name { get; set; }
        public ICollection<Expense_Log> Logs { get; set; }
    }
}
