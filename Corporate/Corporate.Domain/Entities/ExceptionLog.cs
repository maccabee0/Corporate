﻿using System;

namespace Corporate.Domain.Entities
{
    public class ExceptionLog
    {
        public int ExceptionId { get; set; }
        public DateTime ExceptionDate { get; set; }
        public string Source { get; set; }
        public string Details { get; set; }
        public string Message { get; set; }
    }
}
