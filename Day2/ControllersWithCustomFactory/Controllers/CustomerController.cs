using ControllersWithCustomFactory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ControllersWithCustomFactory.Controllers
{
    public class CustomerController : BaseController
    {
        public ActionResult Index()
        {
            return RedirectToAction("User-List");
        }

        [HttpGet]
        [ActionName("Add-User")]
        public ActionResult Add()
        {
            return View("Add");
        }

        [HttpPost]
        [ActionName("Add-User")]
        public async Task<ActionResult> Add(Customer customer)
        {
            customer.Id = DateTime.Now.Millisecond.ToString();
            await Repository.Add(customer);
            return RedirectToAction("User-List");
        }

        [HttpGet]
        [ActionName("User-List")]
        public ActionResult List()
        {
            return View("List", Repository.GetAll());
        }

        [HttpPost]
        [ActionName("User-List")]
        public JsonResult ListPost()
        {
            return Json(Repository.GetAll());
        }
    }
}