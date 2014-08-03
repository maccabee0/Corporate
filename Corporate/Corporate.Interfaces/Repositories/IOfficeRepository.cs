using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;

using Corporate.Domain.Entities;

namespace Corporate.Interfaces.Repositories
{
    public interface IOfficeRepository
    {

        IQueryable<Office> Offices { get; }
        IEnumerable<Office> GetOfficesBy(Expression<Func<Office, bool>> predicate);
        Office GetOfficeByID(int id);
        void SaveOffice(Office office);
        void DeleteOffice(int id);
        void DeleteOffice(Office office);
    }
}
