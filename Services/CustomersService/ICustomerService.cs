using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationServices.CustomersService
{
    public interface ICustomerService
    {
        void CreateCustomer(CustomerDTO customer);

        void DeleteCustomer(CustomerDTO customer);

        void UpdateCustomer(CustomerDTO customer);
        IEnumerable<CustomerDTO> GetActiveCustomers();
    }
}
