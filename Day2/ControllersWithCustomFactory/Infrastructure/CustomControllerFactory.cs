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
            if (controllerName == "user")
            {
                controllerName = "customer";
                requestContext.RouteData.Values["controller"] = controllerName;
            }

            var cntrollerFullName = char.ToUpper(controllerName[0]) + controllerName.Substring(1) + "Controller";
            var targetType = Type.GetType($"{defaultNamespace}.{cntrollerFullName}");
            if (targetType == null)
            {
                targetType = Type.GetType($"{defaultNamespace}.HomeController");
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