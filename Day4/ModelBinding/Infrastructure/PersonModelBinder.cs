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
            model.FirstName = this.GetValue(bindingContext, "FirstName");
            model.LastName = this.GetValue(bindingContext, "LastName");
            model.DoB = this.GetDoBValue(bindingContext, "DoB");
            model.Role = (Role)Enum.Parse(typeof(Role), this.GetRoleValue(bindingContext, "Role", controllerContext.RequestContext.HttpContext.Request.IsLocal), true);
            model.HomeAddress.Line1 = this.GetAddressValue(bindingContext, "Line1");
            model.HomeAddress.Line2 = this.GetAddressValue(bindingContext, "Line2");
            model.HomeAddress.City = this.GetValue(bindingContext, "City");
            model.HomeAddress.Country = this.GetValue(bindingContext, "Country");
            model.HomeAddress.PostalCode = this.GetPostalValue(bindingContext, "PostalCode");
            model.HomeAddress.AddressSummary = this.GetAddressSummaryValue(model);
            return model;
        }

        private void Foo()
        {
        }

        private int Bar()
        {
            return 0;
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

        private DateTime GetDoBValue(ModelBindingContext context, string name)
        {
            DateTime dob;
            var dobString = this.GetValue(context, name);
            if (!DateTime.TryParse(dobString, out dob))
            {
                return dobString == "<Not defined>" ? DateTime.Now : ParseDateString(dobString);
            }
            else
            {
                return dob;
            }
        }

        private DateTime ParseDateString(string date)
        {
            DateTime result;
            if (date.Length < 8 || date.Any(x => char.IsLetter(x)))
            {
                return DateTime.Now;
            }

            DateTime.TryParse($"{date.Substring(0, 2)}/{date.Substring(2, 2)}/{date.Substring(4, 4)}", out result);
            return result;
        }

        // added comment
        private string GetRoleValue(ModelBindingContext context, string role, bool isLocal)
        {
            var result = this.GetValue(context, role);
            if (result == "<Not defined>")
            {
                return "Guest";
            }
            if (result == "Admin" && !isLocal)
            {
                return "User";
            }
            else
            {
                return result;
            }
        }

        // added comment
        private string GetAddressValue(ModelBindingContext context, string addrLine)
        {
            var result = this.GetValue(context, addrLine);
            return result == "PO Box" ? "<Not defined>" : result;
        }

        // added comment
        private string GetPostalValue(ModelBindingContext context, string addrLine)
        {
            var result = this.GetValue(context, addrLine);
            return result.Length < 6 ? "<Not defined>" : result;
        }

        // added comment
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