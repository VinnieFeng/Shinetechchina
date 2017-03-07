using Shinetechchina.Employee.Repository.Shared;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Shinetechchina.Employee.Repository.Core
{
    public class UnitOfWork : Disposable, IUnitOfWork
    {
        private readonly EmployeeDbContext _dataContext;

        private IEmployeeRepository _employeeRepository;

        public IEmployeeRepository EmployeeRepository
        {
            get { return _employeeRepository ?? (_employeeRepository = new EmployeeRepository(_dataContext)); }
        }

        public UnitOfWork(EmployeeDbContext dbContext)
        {
            _dataContext = dbContext;
        }
        public virtual int Commit()
        {
            return _dataContext.SaveChanges();
        }
        public virtual Task<int> CommitAsync()
        {
            return _dataContext.SaveChangesAsync();
        }
        protected override void DisposeCore()
        {
            if (_dataContext != null)
                _dataContext.Dispose();
        }
    }
}
