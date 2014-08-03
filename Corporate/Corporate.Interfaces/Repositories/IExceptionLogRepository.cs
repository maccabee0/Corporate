using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using Corporate.Domain.Entities;

namespace Corporate.Interfaces.Repositories
{
    public interface IExceptionLogRepository
    {
        IQueryable<ExceptionLog> ExceptionLogs { get; }
        IEnumerable<ExceptionLog> GetLogBy(Expression<Func<ExceptionLog, bool>> predicate);
        ExceptionLog GetLogById(int id);
        void SaveLog(ExceptionLog log);
        void DeleteLog(int id);
        void DeleteLog(ExceptionLog log);
    }
}
