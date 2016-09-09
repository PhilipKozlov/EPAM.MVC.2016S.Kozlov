using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModelBinding.Models
{
    public class Person
    {
        public Person()
        {
            this.HomeAddress = new Address();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DoB { get; set; }
        public Role Role { get; set; }
        public Address HomeAddress { get; set; }
    }
}