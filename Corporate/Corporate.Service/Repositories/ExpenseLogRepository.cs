using System;
using System.Collections.Generic;
using System.Linq;

using Corporate.Domain;
using Corporate.Domain.Entities;
using Corporate.Interfaces.Repositories;

namespace Corporate.Service.Repositories
{
    public class ExpenseLogRepository : IExpenseLogRepository
    {
        private CorporateContext _context;
        public ExpenseLogRepository() { _context = new CorporateContext(); }
        public ExpenseLogRepository(CorporateContext context) { _context = context; }
        public IQueryable<Expense_Log> ExpenseLogs
        {
            get { return _context.ExpenseLogs; }
        }

        public IEnumerable<Expense_Log> GetLogsBy(System.Linq.Expressions.Expression<Func<Expense_Log, bool>> predicate)
        {
            return ExpenseLogs.Where(predicate).AsEnumerable();
        }

        public IEnumerable<Expense_Log> GetLogsByOffice(int id)
        {
            return GetLogsBy(e => e.Officeid == id);
        }

        public IEnumerable<Expense_Log> GetLogsByExpense(int id)
        {
            return GetLogsBy(e => e.Expenseid == id);
        }

        public Expense_Log GetLogById(int id)
        {
            return GetLogsBy(e => e.ExpenseLogId == id).FirstOrDefault();
        }


        public void SaveLog(Expense_Log log)
        {
            if (log.ExpenseLogId == 0)
            {
                _context.ExpenseLogs.Add(log);
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

        public void DeleteLog(Expense_Log log)
        {
            _context.ExpenseLogs.Remove(log);
        }

    }
}
