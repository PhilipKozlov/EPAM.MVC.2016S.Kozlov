using Controllers.Infrastructure;
using Controllers.Models;
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
        private CustomerRepository repository;

        public CustomerController()
        {
            this.repository = CustomerRepository.Instance;
        }

        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Add(Customer customer)
        {
            await repository.Add(customer);
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult List()
        {
            return View(repository.List());
        }

        [HttpPost]
        [ActionName("List")]
        public JsonResult ListPost()
        {
            return Json(repository.List());
        }
    }
}