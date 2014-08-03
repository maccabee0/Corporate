using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using Corporate.Domain;
using Corporate.Domain.Entities;
using Corporate.Interfaces.Repositories;

namespace Corporate.Service.Repositories
{
    public class ExpenseRepository:IExpenseRepository
    {
        private CorporateContext _context;
        public ExpenseRepository() { _context = new CorporateContext(); }
        public ExpenseRepository(CorporateContext context) { _context = context; }
        public IQueryable<Expense> Expenses
        {
            get { return _context.Expenses; }
        }

        public IEnumerable<Expense> GetExpencesBy(Expression<Func<Expense, bool>> predicate)
        {
            return Expenses.Where(predicate).ToList();
        }

        public Expense GetExpenseByID(int id)
        {
            return GetExpencesBy(e=>e.Expenseid==id).FirstOrDefault();
        }

        public void SaveExpense(Expense expense)
        {
            if (expense.Expenseid == 0)
            {
                _context.Expenses.Add(expense);
            }
            else 
            {
                _context.Entry(expense).State = System.Data.Entity.EntityState.Modified;
            }
            _context.SaveChanges();
        }

        public void DeleteExpense(int id)
        {
            DeleteExpense(GetExpenseByID(id));
        }

        public void DeleteExpense(Expense expense)
        {
            _context.Expenses.Remove(expense);
        }
    }
}
