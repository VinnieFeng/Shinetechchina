using System.Collections.Generic;

namespace Shinetechchina.Employee.Business.Shared
{
    public interface IEmployeeMgr
    {
        /// <summary>
        /// get employee by employeeid
        /// </summary>
        /// <param name="id">employeeid</param>
        /// <returns>employee model</returns>
        EmployeeModel GetEmployee(string id);

        /// <summary>
        /// get all employee with out paged
        /// </summary>
        /// <returns>employee model list</returns>
        IEnumerable<EmployeeModel> GetAllEmployee();

        /// <summary>
        /// update employee by employee id
        /// </summary>
        /// <param name="employee">employee model</param>
        /// <returns>is update success </returns>
        void UpdateEmployee(EmployeeModel employee);

        /// <summary>
        /// add a employee 
        /// </summary>
        /// <param name="employee">employee model</param>
        /// <returns>is add success </returns>
        void AddEmployee(EmployeeModel employee);

        /// <summary>
        /// delete an employee by id
        /// </summary>
        /// <param name="id">employee ID</param>
        /// <returns>is success </returns>
        void DeleteEmployee(string id);
    }
}
