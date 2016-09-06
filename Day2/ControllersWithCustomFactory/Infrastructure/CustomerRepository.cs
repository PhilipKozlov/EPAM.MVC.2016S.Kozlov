using ControllersWithCustomFactory.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControllersWithCustomFactory.Infrastructure
{
    public class CustomerRepository
    {
        #region Fields

        private IList<Customer> customers;
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
            await Task.Run(() => this.customers.Add(customer));
        }

        public async Task<bool> Remove(string id)
        {
            return await Task.Run(() => this.customers.Remove(this.customers.Where(c => c.Id == id).SingleOrDefault()));
        }

        public IList<Customer> GetAll()
        {
            return this.customers;
        }

        public async Task<Customer> GetById(string id)
        {
            return await Task.Run(() => this.customers.Where(c => c.Id == id).SingleOrDefault());
        }
        #endregion
    }
}