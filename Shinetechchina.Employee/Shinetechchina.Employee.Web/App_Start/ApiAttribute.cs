using Shinetechchina.Employee.Infrastructure.Logging;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Shinetechchina.Employee.Web
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext.ModelState.IsValid == false)
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(
                    HttpStatusCode.BadRequest, actionContext.ModelState);
            }
        }
    }

    public class CustomerExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            ILogger log = new Logger();
            log.Error("Error in CustomerExceptionFilterAttribute", context.Exception);
            context.Request.CreateErrorResponse(HttpStatusCode.NotFound, context.Exception);
        }
    }
}