namespace Shinetechchina.Employee.Repository.Core
{
    using System.Data.Entity;
    using Shared;

    public partial class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext()
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
