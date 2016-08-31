using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int id = 11)
        {
            ViewBag.action = "Index";
            ViewBag.controller = "HomeController";
            return View();
        }
    }
}
