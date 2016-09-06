using System.Web.Mvc;
using System.Web.Routing;

namespace Controllers.Infrastructure
{
    public class CustomControllerFactory : DefaultControllerFactory
    {
        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            if (controllerName.ToLower() == "user")
            {
                controllerName = "customer";
                requestContext.RouteData.Values["controller"] = controllerName;
            }

            return base.CreateController(requestContext, controllerName);
        }
    }
}