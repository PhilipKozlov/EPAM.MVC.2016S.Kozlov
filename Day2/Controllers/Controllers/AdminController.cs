using Controllers.Infrastructure;
using Controllers.Models;
using Day2.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Controllers.Controllers
{
    public class AdminController : Controller
    {
        private CustomerRepository repository;

        public AdminController()
        {
            this.repository = CustomerRepository.Instance;
        }

        [Local]
        public ActionResult Index()
        {
            return View(repository.List());
        }

        [Local]
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [Local]
        [HttpPost]
        public async Task<ActionResult> Add(Customer customer)
        {
            await repository.Add(customer);
            return RedirectToAction("Index");
        }

        [Local]
        public async Task<ActionResult> Remove(Customer customer)
        {
            await repository.Remove(customer);
            return RedirectToAction("Index");
        }

    }
}