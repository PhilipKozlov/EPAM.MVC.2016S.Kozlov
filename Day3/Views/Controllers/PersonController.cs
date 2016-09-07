using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Views.Infrastructure;

namespace Views.Controllers
{
    public class PersonController : Controller
    {
        private PersonRepository repository;

        public PersonController()
        {
            this.repository = PersonRepository.Instance;
        }

        public ActionResult Person()
        {
            return View(repository.GetAll().FirstOrDefault());
        }

        [ChildActionOnly]
        public ActionResult Footer(string faction)
        {
            return PartialView((object)faction);
        }

        public ActionResult SwitchSides()
        {
            var person = repository.GetAll().FirstOrDefault();
            person.Faction = "Dark";
            return RedirectToAction("Person", repository.GetAll().FirstOrDefault());
        }
    }
}