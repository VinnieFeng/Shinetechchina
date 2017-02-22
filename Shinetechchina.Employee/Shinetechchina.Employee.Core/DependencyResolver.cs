﻿using Castle.MicroKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shinetechchina.Employee.Core
{
    public class DependencyResolver
    {
        private readonly IKernel kernel;

        public DependencyResolver(IKernel kernel)
        {
            this.kernel = kernel;
        }
              

        public object GetService(Type type)
        {
             return kernel.HasComponent(type) ? kernel.Resolve(type) : null;
        }
            

        public IEnumerable<object> GetServices(Type type)
        {
            return kernel.ResolveAll(type).Cast<object>();
        }

        public void Dispose()
        {
        }
    }
}
