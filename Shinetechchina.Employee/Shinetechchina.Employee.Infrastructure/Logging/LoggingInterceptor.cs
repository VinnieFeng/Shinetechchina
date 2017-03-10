using Castle.DynamicProxy;
using System;
using System.Reflection;

namespace Shinetechchina.Employee.Infrastructure.Logging
{
    public class LoggingInterceptor : IInterceptor
    {
        private ILogger logger { get; set; }

        public LoggingInterceptor(ILogger logger)
        {
            this.logger = logger;
        }

        public void Intercept(IInvocation invocation)
        {
            Type type = invocation.TargetType;
            MethodInfo method = invocation.MethodInvocationTarget;
            try
            {
               // logger.Debug($"beftore {method.Name},{type.Name}");
                //Write(OnBeforeProceedMessage(type, method));
                invocation.Proceed();
                //Write(OnAfterProceedMessage(type, method));
                //logger.Debug($"after {method.Name},{type.Name}");
            }
            catch (Exception e)
            {
                logger.Error($"error in {method.Name},{type.Name}", e);
                throw e;
            }
        }
    }
}
