using Controllers.Infrastructure;
using System.Web.Mvc;
using System.Web.Routing;

namespace Controllers
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteTable.Routes.MapMvcAttributeRoutes();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ControllerBuilder.Current.SetControllerFactory(new CustomControllerFactory());
        }
    }
}
