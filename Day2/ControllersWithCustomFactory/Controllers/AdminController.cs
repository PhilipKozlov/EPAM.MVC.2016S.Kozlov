using ControllersWithCustomFactory.Models;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ControllersWithCustomFactory.Controllers
{
    public class AdminController : BaseController
    {
        public ActionResult Index()
        {
            return View(this.Repository.GetAll());
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
            await this.Repository.Add(customer);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Remove(string id)
        {
            await this.Repository.Remove(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Edit(string id)
        {
            return View(await this.Repository.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Customer customer)
        {
            await this.Repository.Remove(customer.Id);
            await this.Repository.Add(customer);
            return RedirectToAction("Index");
        }

    }
}