using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MobileStore.Controllers
{
    //Denying Internet Explorer
    public abstract class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Request.Headers.ContainsKey("User-Agent"))
            {
                var useragent = context.HttpContext.Request.Headers["User-Agent"].FirstOrDefault();

                if (useragent.Contains("MSIE") || useragent.Contains("Trident"))
                {
                    context.Result = Content("Internet Explorer is not supported");
                }
            }
            base.OnActionExecuting(context);
        }
    }
}