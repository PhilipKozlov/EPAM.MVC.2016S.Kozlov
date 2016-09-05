﻿using Controllers.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Controllers.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
            this.Repository = CustomerRepository.Instance;
        }

        public CustomerRepository Repository { get; }

        protected override void HandleUnknownAction(string actionName)
        {
            this.View("Error404").ExecuteResult(this.ControllerContext);
        }
    }
}