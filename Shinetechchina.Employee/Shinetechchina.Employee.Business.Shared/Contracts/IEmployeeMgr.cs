﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shinetechchina.Employee.Business.Shared
{
    public interface IEmployeeMgr
    {
        EmployeeModel GetEmployee(string ID);
        IEnumerable<EmployeeModel> GetAllEmployee();
        EmployeeModel UpdateEmployee(EmployeeModel employee);
        EmployeeModel AddEmployee(EmployeeModel employee);
        EmployeeModel DeleteEmployee(EmployeeModel employee);
    }
}
