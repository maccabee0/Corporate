using System;
using System.ComponentModel.DataAnnotations;

namespace Corporate.Domain.Entities
{
    public class ExceptionLog
    {
        [Key]
        public int ExceptionId { get; set; }
        public DateTime ExceptionDate { get; set; }
        public string Source { get; set; }
        public string Details { get; set; }
        public string Message { get; set; }
    }
}
