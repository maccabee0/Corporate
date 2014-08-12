using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using Corporate.Domain;
using Corporate.Domain.Entities;
using Corporate.Interfaces.Repositories;

using Microsoft.Practices.Prism.Logging;

namespace Corporate.Service.Repositories
{
    public class ExceptionRepository : IExceptionLogRepository,ILoggerFacade
    {
        private CorporateContext _context;
        //public ExceptionRepository() { _context = new CorporateContext(); }
        public ExceptionRepository(CorporateContext context) { _context = context; }
        public IQueryable<ExceptionLog> ExceptionLogs
        {
            get { return _context.ExceptionLogs; }
        }

        public IEnumerable<ExceptionLog> GetLogBy(Expression<Func<ExceptionLog, bool>> predicate)
        {
            return ExceptionLogs.Where(predicate).AsEnumerable();
        }

        public ExceptionLog GetLogById(int id)
        {
            return GetLogBy(l => l.ExceptionId == id).FirstOrDefault();
        }

        public void SaveLog(ExceptionLog log)
        {
            if (log.ExceptionId == 0)
            {
                _context.ExceptionLogs.Add(log);
            }
            else
            {
                _context.Entry(log).State = System.Data.Entity.EntityState.Modified;
            }
            _context.SaveChanges();
        }

        public void DeleteLog(int id)
        {
            DeleteLog(GetLogById(id));
        }

        public void DeleteLog(ExceptionLog log)
        {
            _context.ExceptionLogs.Remove(log);
        }

        public void Log(string message, Category category, Priority priority)
        {
            var log = new ExceptionLog
            {
                ExceptionDate = DateTime.Now,
                Details = message + category.GetType() + priority.GetType(),
                Message = message
            };
            SaveLog(log);
        }
    }
}
