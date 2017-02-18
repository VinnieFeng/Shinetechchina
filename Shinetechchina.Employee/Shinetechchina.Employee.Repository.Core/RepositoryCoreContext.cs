using System;
using System.Collections.Generic;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Shinetechchina.Employee.Core;
using Shinetechchina.Employee.Repository.Shared;

namespace Shinetechchina.Employee.Repository.Core
{
    public class RepositoryCoreContext : ContextBase
    {


        public override Dictionary<Type, Type> GetRegister()
        {
            return new Dictionary<Type, Type>
            {
                [typeof(IEmployeeRepository)] = typeof(EmployeeRepository)
            };
        }


    }
}
