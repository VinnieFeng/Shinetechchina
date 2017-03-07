using System.Threading.Tasks;

namespace Shinetechchina.Employee.Repository.Shared
{
    public interface IUnitOfWork
    {

        int Commit();
        Task<int> CommitAsync();

        IEmployeeRepository EmployeeRepository { get; }
    }
}
