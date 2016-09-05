using ControllersWithCustomFactory.Infrastructure;
using ControllersWithCustomFactory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ControllersWithCustomFactory.Controllers
{
    public class AdminController : BaseController
    {
        public ActionResult Index()
        {
            return View(Repository.GetAll());
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Add(Customer customer)
        {
            customer.Id = DateTime.Now.Millisecond.ToString();
            await Repository.Add(customer);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Remove(string id)
        {
            await Repository.Remove(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Edit(string id)
        {
            return View(await Repository.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Customer customer)
        {
            await Repository.Remove(customer.Id);
            await Repository.Add(customer);
            return RedirectToAction("Index");
        }

    }
}