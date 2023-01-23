using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrometheusDemo.Infrasturcture
{
    public class LogAttribute : ActionFilterAttribute,IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            
            var abc = filterContext.HttpContext.Request.Url;
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
        }
    }
}