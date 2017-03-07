using System;
using System.Linq;
using System.Collections.Generic;
using Shinetechchina.Employee.Business.Shared;
using Shinetechchina.Employee.Repository.Shared;

namespace Shinetechchina.Employee.Business.Core
{
    public class EmployeeMgr : IEmployeeMgr
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeMgr(IUnitOfWork employeeUnitOfWork)
        {
            _unitOfWork = employeeUnitOfWork;
        }

        public void AddEmployee(EmployeeModel employee)
        {
            var employeeEntry = employee.ToEntry();
            employeeEntry.EmployeeID = $"E{DateTime.Now.Ticks.ToString()}";//mock emplouyee ID
            employeeEntry.Created = DateTime.Now;
            employeeEntry.Modified = DateTime.Now;
            employeeEntry.Id = Guid.NewGuid();
            _unitOfWork.EmployeeRepository.AddEmployee(employeeEntry);
            _unitOfWork.Commit();
        }

        public void DeleteEmployee(string employeeID)
        {
            if (string.IsNullOrEmpty(employeeID))
            {
                throw new ArgumentNullException(nameof(employeeID));
            }
            _unitOfWork.EmployeeRepository.DeleteEmployee(employeeID);
            _unitOfWork.Commit();
        }

        public IEnumerable<EmployeeModel> GetAllEmployee()
        {
            var employeeList = _unitOfWork.EmployeeRepository.GetAllEmployee().Select(t => new EmployeeModel(t));
            return employeeList;
        }

        public EmployeeModel GetEmployee(string employeeID)
        {
            if (string.IsNullOrEmpty(employeeID))
            {
                throw new ArgumentNullException(nameof(employeeID));
            }
            var employeeEntity = _unitOfWork.EmployeeRepository.GetEmployee(employeeID);
            return new EmployeeModel(employeeEntity);
        }

        public void UpdateEmployee(EmployeeModel employee)
        {
            var employeeEntry = employee.ToEntry();
            employeeEntry.Modified = DateTime.Now;
            _unitOfWork.EmployeeRepository.UpdateEmployee(employeeEntry);
            _unitOfWork.Commit();
        }
    }
}
