using System.Data.Entity;
using System.Data.Entity.Infrastructure;

using Corporate.Domain.Entities;

namespace Corporate.Domain
{
    public class CorporateContext : DbContext
    {
        public CorporateContext()
            : base("name=CorporateContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Office> Offices { set; get; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Expense_Log> ExpenseLogs { get; set; }
        public DbSet<ExceptionLog> ExceptionLogs { get; set; }
    }
}
