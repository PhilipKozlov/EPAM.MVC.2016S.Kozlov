using ControllersWithCustomFactory.Controllers;
using System.Web.Mvc;

namespace ControllersWithCustomFactory.Infrastructure
{
    public class CustomActionInvoker : IActionInvoker
    {
        public bool InvokeAction(ControllerContext controllerContext, string actionName)
        {
            return !controllerContext.RequestContext.HttpContext.Request.IsLocal ? (controllerContext.Controller is AdminController) ? false : true : true;
        }
    }
}