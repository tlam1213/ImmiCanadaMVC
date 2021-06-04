using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ImmiCanada.Controllers
{
    public class BaseController : Controller
    {

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string actionName = filterContext.ActionDescriptor.ActionName;
            string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;

            string banner = "default-banner";
            switch (controllerName)
            {
                case "Service":
                    banner = "service-banner";
                    break;
                default:
                    banner = "default-banner";
                    break;
            }
            ViewData["banner"] = banner;
            base.OnActionExecuting(filterContext);
        }
    }
}