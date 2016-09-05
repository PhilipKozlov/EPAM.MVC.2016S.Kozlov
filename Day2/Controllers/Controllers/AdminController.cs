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
    public class AdminController : BaseController
    {
        [Local]
        public ActionResult Index()
        {
            return View(Repository.GetAll());
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
            customer.Id = DateTime.Now.Millisecond.ToString();
            await Repository.Add(customer);
            return RedirectToAction("Index");
        }

        [Local]
        public async Task<ActionResult> Remove(string id)
        {
            await Repository.Remove(id);
            return RedirectToAction("Index");
        }

        [Local]
        [HttpGet]
        public async Task<ActionResult> Edit(string id)
        {
            return View(await Repository.GetById(id));
        }

        [Local]
        [HttpPost]
        public async Task<ActionResult> Edit(Customer customer)
        {
            await Repository.Remove(customer.Id);
            await Repository.Add(customer);
            return RedirectToAction("Index");
        }

    }
}