using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Corporate.Domain;
using Corporate.Interfaces.Repositories;

namespace Corporate.Service.Repositories
{
    public class GenericRepository<T>//:IRepository<T>
    {
        //private CorporateContext _context;
        ////private DbSet<TEntity> _set;
        //public GenericRepository()
        //{
        //    _context = new CorporateContext();
        //    //_set = _context.Set<T>();
        //}
        //public GenericRepository(CorporateContext context)
        //{
        //    _context = context;
        //}

        //public IEnumerable<T> Entities
        //{
        //    get { throw new NotImplementedException(); }
        //}

        //public IEnumerable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        //{
        //    throw new NotImplementedException();
        //}

        //public T GetEntityById(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public void SaveEntity(T entity)
        //{
        //    throw new NotImplementedException();
        //}

        //public bool DeleteEntity(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public bool DeleteEntity(T entity)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
