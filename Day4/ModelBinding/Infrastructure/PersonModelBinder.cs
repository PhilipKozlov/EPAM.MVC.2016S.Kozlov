using ModelBinding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModelBinding.Infrastructure
{
    public class PersonModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var model = (Person)bindingContext.Model ?? new Person();
            model.FirstName = GetValue(bindingContext, "FirstName");
            model.LastName = GetValue(bindingContext, "FirstName");
            // TODO: implement custom date time format
            model.DoB = DateTime.Parse(GetValue(bindingContext, "DoB"));
            model.Role = (Role)Enum.Parse(typeof(Role), GetRoleValue(bindingContext, "Role", controllerContext.RequestContext.HttpContext.Request.IsLocal), true);
            model.HomeAddress.Line1 = GetAddressValue(bindingContext, "HomeAddress.Line1");
            model.HomeAddress.Line2 = GetAddressValue(bindingContext, "HomeAddress.Line2");
            model.HomeAddress.City = GetValue(bindingContext, "HomeAddress.City");
            model.HomeAddress.Country = GetValue(bindingContext, "HomeAddress.Country");
            model.HomeAddress.PostalCode = GetPostalValue(bindingContext, "HomeAddress.PostalCode");
            model.HomeAddress.AddressSummary = GetAddressSummaryValue(model);
            return model;
        }

        private string GetValue(ModelBindingContext context, string name)
        {
            var result = context.ValueProvider.GetValue(name);
            if (result == null || result.AttemptedValue == "")
            {
                return "<Not defined>";
            }
            else
            {
                return result.AttemptedValue;
            }
        }

        private string GetRoleValue(ModelBindingContext context, string role, bool isLocal)
        {
            var result = context.ValueProvider.GetValue(role);
            if (result == null || result.AttemptedValue == "")
            {
                return "Guest";
            }
            if (result.AttemptedValue == "Admin" && !isLocal)
            {
                return "User";
            }
            else
            {
                return result.AttemptedValue;
            }
        }

        private string GetAddressValue(ModelBindingContext context, string addrLine)
        {
            var result = context.ValueProvider.GetValue(addrLine);
            if (result == null || result.AttemptedValue == "" || result.AttemptedValue == "PO Box")
            {
                return "<Not defined>";
            }
            else
            {
                return result.AttemptedValue;
            }
        }

        private string GetPostalValue(ModelBindingContext context, string addrLine)
        {
            var result = context.ValueProvider.GetValue(addrLine);
            if (result.AttemptedValue.Length < 6 || result == null || result.AttemptedValue == "")
            {
                return "<Not defined>";
            }
            else
            {
                return result.AttemptedValue;
            }
        }

        private string GetAddressSummaryValue(Person model)
        {
            if (model.HomeAddress.Line1 == "<Not defined>")
            {
                return "No Personal Address";
            }
            return model.HomeAddress.PostalCode + " " + model.HomeAddress.City + "," + model.HomeAddress.Line1;
        }
    }
}