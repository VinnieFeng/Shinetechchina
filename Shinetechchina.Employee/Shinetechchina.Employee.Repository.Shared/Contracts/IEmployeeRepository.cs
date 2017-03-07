using System.Collections.Generic;

namespace Shinetechchina.Employee.Repository.Shared
{
    public interface IEmployeeRepository
    {
        /// <summary>
        /// get an employee by employee id
        /// </summary>
        /// <param name="id">employee id </param>
        /// <returns>employee entry</returns>
        EmployeeEntry GetEmployee(string id);

        /// <summary>
        /// get all employee without paged
        /// </summary>
        /// <returns>employee list</returns>
        IEnumerable<EmployeeEntry> GetAllEmployee();

        /// <summary>
        /// add an employee 
        /// </summary>
        /// <param name="employee">employee entry</param>
        /// <returns>is success </returns>
        void AddEmployee(EmployeeEntry employee);

        /// <summary>
        /// delete an employee 
        /// </summary>
        /// <param name="employee">emplouee id</param>
        /// <returns>is success </returns>
        void DeleteEmployee(string employeeID);

        /// <summary>
        /// update an employee 
        /// </summary>
        /// <param name="employee">emplouyee entry</param>
        /// <returns>is success </returns>
        void UpdateEmployee(EmployeeEntry employee);
    }
}
