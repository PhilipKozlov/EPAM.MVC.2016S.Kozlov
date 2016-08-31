using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCRouting.Controllers
{
    public class HelloController : Controller
    {
        // GET: Hello
        [Route("greetings/{name}/{lastName}")]
        public ActionResult Index(string name, string lastName)
        {
            ViewBag.name = name;
            ViewBag.lastName = lastName;
            return View();
        }
    }
}