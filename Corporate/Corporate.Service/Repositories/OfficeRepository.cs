using System;
using System.Collections.Generic;
using System.Linq;

using Corporate.Domain.Entities;
using Corporate.Domain;
using Corporate.Interfaces.Repositories;

using Microsoft.Practices.Unity;

namespace Corporate.Service.Repositories
{
    public class OfficeRepository : IOfficeRepository
    {
        //[Dependency]
        public CorporateContext Context { get; set; }
        //public OfficeRepository()
        //{
        //    Context = new CorporateContext();
        //}

        public OfficeRepository(CorporateContext context)
        {
            Context = context;
        }

        public IQueryable<Office> Offices { get { return Context.Offices; } }

        public IEnumerable<Office> GetOfficesBy(System.Linq.Expressions.Expression<Func<Office, bool>> predicate)
        {
            return Offices.Where(predicate).ToList();
        }

        public Office GetOfficeById(int id)
        {
            return GetOfficesBy(o => o.Officeid == id).FirstOrDefault();
        }

        public void SaveOffice(Office entity)
        {
            if (GetOfficeById(entity.Officeid) == null)
            {
                Context.Offices.Add(entity);
            }
            else
            {
                Context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            }
            Context.SaveChanges();
        }

        public void DeleteOffice(int id)
        {
            DeleteOffice(GetOfficeById(id));
        }

        public void DeleteOffice(Office office)
        {
            Context.Offices.Remove(office);
        }


    }
}
