namespace Shinetechchina.Employee.Repository.Core
{
    using Migrations;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using Web.Migrations;

    public partial class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext()
            : base("name=EmployeeContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EmployeeDbContext, Configuration>());
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
