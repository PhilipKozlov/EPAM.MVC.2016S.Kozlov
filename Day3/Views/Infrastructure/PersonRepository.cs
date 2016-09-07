using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Views.Models;

namespace Views.Infrastructure
{
    public class PersonRepository
    {
        private static PersonRepository instance = new PersonRepository();
        private IList<Person> persons;

        private PersonRepository()
        {
            this.persons = new List<Person>();
            this.persons.Add(new Person { Name = "John", LastName = "Doe", Faction = "Light" });
        }

        public static PersonRepository Instance => instance;

        public IList<Person> GetAll()
        {
            return this.persons;
        }

        public void Add(Person person)
        {
            this.persons.Add(person);
        }
    }
}