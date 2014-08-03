using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using Corporate.Domain.Entities;

namespace Corporate.Interfaces.Repositories
{
    public interface IExpenseRepository
    {
        IQueryable<Expense> Expenses{get;}
        IEnumerable<Expense> GetExpencesBy(Expression<Func<Expense, bool>> predicate);
        Expense GetExpenseByID(int id);
        void SaveExpense(Expense expense);
        void DeleteExpense(int id);
        void DeleteExpense(Expense expense);
    }
}
