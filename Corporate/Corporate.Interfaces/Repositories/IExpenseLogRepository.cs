using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using Corporate.Domain;
using Corporate.Domain.Entities;

namespace Corporate.Interfaces.Repositories
{
    public interface IExpenseLogRepository
    {
        IQueryable<Expense_Log> ExpenseLogs { get; }
        IEnumerable<Expense_Log> GetLogsBy(Expression<Func<Expense_Log, bool>> predicate);
        IEnumerable<Expense_Log> GetLogsByOffice(int officeId);
        IEnumerable<Expense_Log> GetLogsByExpense(int expenseId);
        Expense_Log GetLogById(int id);
        void SaveLog(Expense_Log log);
        void DeleteLog(int id);
        void DeleteLog(Expense_Log log);
    }
}
