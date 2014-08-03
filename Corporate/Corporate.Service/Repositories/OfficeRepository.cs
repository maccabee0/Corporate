using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;

using Corporate.Domain.Entities;
using Corporate.Domain;
using Corporate.Interfaces.Repositories;

namespace Corporate.Service.Repositories
{
    public class OfficeRepository : IOfficeRepository
    {
        private CorporateContext _context;
        public OfficeRepository()
        {
            _context = new CorporateContext();
        }

        public OfficeRepository(CorporateContext context)
        {
            _context = context;
        }

        public IQueryable<Office> Offices { get { return _context.Offices; } }

        public IEnumerable<Office> GetOfficesBy(System.Linq.Expressions.Expression<Func<Office, bool>> predicate)
        {
            return Offices.Where(predicate).ToList();
        }

        public Office GetOfficeByID(int id)
        {
            return GetOfficesBy(o => o.Officeid == id).FirstOrDefault();
        }

        public void SaveOffice(Office entity)
        {
            if (GetOfficeByID(entity.Officeid) == null)
            {
                _context.Offices.Add(entity);
            }
            else
            {
                _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            }
            _context.SaveChanges();
        }

        public void DeleteOffice(int id)
        {
            DeleteOffice(GetOfficeByID(id));
        }

        public void DeleteOffice(Office entity)
        {
            _context.Offices.Remove(entity);
        }


    }
}
