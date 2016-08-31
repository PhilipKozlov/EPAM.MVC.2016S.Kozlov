using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace JsonControllers
{
    public class HomeController : Controller
    {
        public JsonResult Index(int id = 1)
        {
            return Json(new { action = "Index", controller = "HomeController" }, JsonRequestBehavior.AllowGet);
        }
    }
}
