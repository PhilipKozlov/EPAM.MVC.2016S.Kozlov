using System;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;

namespace ControllersWithCustomFactory.Infrastructure
{
    public class CustomControllerFactory : IControllerFactory
    {
        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            var defaultNamespace = "ControllersWithCustomFactory.Controllers";
            var defaultControllerType = Type.GetType($"{defaultNamespace}.HomeController");
            if (controllerName.ToLower() == "user")
            {
                controllerName = "customer";
                requestContext.RouteData.Values["controller"] = controllerName;
            }
            // return default controller, if request for AdminController isn't local
            else if (controllerName.ToLower() == "admin")
            {
                if (!requestContext.HttpContext.Request.IsLocal)
                {
                    requestContext.RouteData.Values["controller"] = "home";
                    return (IController)DependencyResolver.Current.GetService(defaultControllerType);
                }
            }

            var controllerFullName = char.ToUpper(controllerName[0]) + controllerName.Substring(1) + "Controller";
            var targetType = Type.GetType($"{defaultNamespace}.{controllerFullName}");
            if (targetType == null)
            {
                targetType = defaultControllerType;
                requestContext.RouteData.Values["controller"] = "home";
            }

            return targetType == null ? null : (IController)DependencyResolver.Current.GetService(targetType);
        }

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            return controllerName.ToLower() == "home" ? SessionStateBehavior.Disabled : SessionStateBehavior.Default;
        }

        public void ReleaseController(IController controller)
        {
            var disposable = controller as IDisposable;
            disposable?.Dispose();
        }
    }
}