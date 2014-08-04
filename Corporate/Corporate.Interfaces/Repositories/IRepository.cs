using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Corporate.Interfaces.Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> Entities { get; }
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        T GetEntityById(int id);
        void SaveEntity(T entity);
        bool DeleteEntity(int id);
        bool DeleteEntity(T entity);
    }
}
