using System;
using System.Collections.Generic;
using System.Linq;

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

        public Office GetOfficeById(int id)
        {
            return GetOfficesBy(o => o.Officeid == id).FirstOrDefault();
        }

        public void SaveOffice(Office entity)
        {
            if (GetOfficeById(entity.Officeid) == null)
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
            DeleteOffice(GetOfficeById(id));
        }

        public void DeleteOffice(Office office)
        {
            _context.Offices.Remove(office);
        }


    }
}
