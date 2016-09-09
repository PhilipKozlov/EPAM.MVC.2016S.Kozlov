using ModelBinding.Infrastructure;
using ModelBinding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModelBinding.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var isFormProvider = ((IEnumerable<IValueProvider>)ControllerContext.Controller.ValueProvider).OfType<CustomFormValueProvider>().Count() > 0;
            if (isFormProvider)
            {
                ViewBag.Action = "Index";
                ViewBag.Method = FormMethod.Post;
            }
            else
            {
                ViewBag.Action = "IndexGet";
                ViewBag.Method = FormMethod.Get;
            }

            return View(new Person());
        }

        [HttpPost]
        public ActionResult Index(Person model)
        {
            return View("Person", model);
        }

        public ActionResult IndexGet()
        {
            var model = new Person();
            if (TryUpdateModel(model))
            {
                return View("Person", model);
            }
            return View("Index", model);
        }

        public ActionResult Person(Person model)
        {
            return View(model);
        }
    }
}