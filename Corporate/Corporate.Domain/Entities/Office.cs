using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Corporate.Domain.Entities
{
    public class Office
    {
        [Key]
        public int Officeid { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Expense_Log> Logs { get; set; }
    }
}
