using Controllers.Infrastructure;
using Controllers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Controllers.Controllers
{
    public class CustomerController : Controller
    {
        private CustomerRepository repository;

        public CustomerController()
        {
            this.repository = CustomerRepository.Instance;
        }

        // GET: Customer
        public ActionResult Index()
        {
            return View();
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