using ControllersWithCustomFactory.Infrastructure;
using System.Web.Mvc;

namespace ControllersWithCustomFactory.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
            this.Repository = CustomerRepository.Instance;
            //this.ActionInvoker = new CustomActionInvoker();
        }

        public CustomerRepository Repository { get; }

        protected override void HandleUnknownAction(string actionName)
        {
            this.View("Error404").ExecuteResult(this.ControllerContext);
        }
    }
}