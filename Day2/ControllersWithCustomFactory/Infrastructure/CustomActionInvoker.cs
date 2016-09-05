using ControllersWithCustomFactory.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControllersWithCustomFactory.Infrastructure
{
    public class CustomActionInvoker : IActionInvoker
    {
        public bool InvokeAction(ControllerContext controllerContext, string actionName)
        {
            if (!controllerContext.RequestContext.HttpContext.Request.IsLocal && (controllerContext.Controller is AdminController))
            {
                return false;
            }
            return true;

        }
    }
}