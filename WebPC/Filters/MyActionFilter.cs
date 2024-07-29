using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Diagnostics;

namespace WebPC.Filters
{
    public class MyActionFilter : FilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Debug.WriteLine("Action Executing");
            filterContext.Controller.ViewBag.Number = 5;
        }
    }
}