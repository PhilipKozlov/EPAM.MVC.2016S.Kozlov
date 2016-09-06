using Controllers.Models;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Controllers.Controllers
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
            await this.Repository.Add(customer);
            return RedirectToAction("User-List");
        }

        [HttpGet]
        [ActionName("User-List")]
        public ActionResult List()
        {
            return View("List", this.Repository.GetAll());
        }

        [HttpPost]
        [ActionName("User-List")]
        public JsonResult ListPost()
        {
            return Json(this.Repository.GetAll());
        }
    }
}