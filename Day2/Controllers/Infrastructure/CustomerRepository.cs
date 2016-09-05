using Controllers.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Controllers.Infrastructure
{
    public class CustomerRepository
    {
        #region Fields
        private IList<Customer> customers { get; set; }
        private static readonly CustomerRepository instance;
        #endregion

        #region Constructors
        private CustomerRepository()
        {
            customers = new List<Customer>();
        }

        static CustomerRepository()
        {
            instance = new CustomerRepository();
        }
        #endregion

        #region Properties
        public static CustomerRepository Instance => instance;
        #endregion

        #region Public Methods
        public async Task Add(Customer customer)
        {
            await Task.Run(() => customers.Add(customer));
        }

        public async Task<bool> Remove(Customer customer)
        {
            return await Task.Run(() => customers.Remove(customer));
        }

        public IList<Customer> List()
        {
            return customers;
        }
        #endregion
    }
}