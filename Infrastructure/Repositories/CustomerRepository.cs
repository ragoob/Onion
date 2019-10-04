using Core.Domain;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DbSet<Customer> _customers;
        public CustomerRepository(DbSet<Customer> customers)
        {
            _customers = customers;
        }
        public void AddNewCustomer(Customer customer)
        {
            _customers.Add(customer);
        }

        public IEnumerable<Customer> GetActiveCustomers()
        {
          return _customers.Where(c => c.IsActive).AsEnumerable();
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _customers.AsEnumerable();
        }

        public Customer GetCustomerById(int id)
        {
            return _customers.Find(id);
        }

        public IEnumerable<Customer> GetInActiveCustomers()
        {
            return _customers.Where(c => !c.IsActive).AsEnumerable();
        }

        public void RemoveCustomer(Customer customer)
        {
            _customers.Remove(customer);
        }
    }
}
