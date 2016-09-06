using System.Web.Mvc;
using System.Web.SessionState;

namespace Controllers.Controllers
{
    [SessionState(SessionStateBehavior.Disabled)]
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}