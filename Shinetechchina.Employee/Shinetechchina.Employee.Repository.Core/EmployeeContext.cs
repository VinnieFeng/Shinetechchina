namespace Shinetechchina.Employee.Repository.Core
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Shared.Models;

    public partial class EmployeeContext : DbContext
    {
        public EmployeeContext()
            : base("name=EmployeeContext")
        {
        }

        public virtual DbSet<EmployeeEntity> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeEntity>().ToTable("Employee")
                .Property(e => e.EmployeeID)
                .IsFixedLength();
        }
    }
}
