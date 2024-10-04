using Microsoft.AspNetCore.Mvc.Filters;

namespace MVC_Day1.Models
{
    public class MyErrorFilter:ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);
        }
    }
}
