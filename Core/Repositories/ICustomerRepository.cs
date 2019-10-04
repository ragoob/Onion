using Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repositories
{
    public interface ICustomerRepository
    {
        void AddNewCustomer(Customer customer);
        void RemoveCustomer(Customer customer);
        Customer GetCustomerById(int id);
        IEnumerable<Customer> GetActiveCustomers();
        IEnumerable<Customer> GetInActiveCustomers();
        IEnumerable<Customer> GetAllCustomers();
    }
}
