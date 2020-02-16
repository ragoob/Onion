using Core;
using Core.Domain;
using Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace ApplicationServices.CustomersService
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
        }
        public void CreateCustomer(CustomerDTO customer)
        {
            var entity = new Customer(
                customer.Name, customer.Address, customer.IsActive
                );
            _customerRepository.AddNewCustomer(entity);
            _unitOfWork.CommitChanges();
            customer.Id = entity.Id;
        }

        public void DeleteCustomer(CustomerDTO customer)
        {
            _customerRepository.RemoveCustomer(new Customer(
               customer.Id, customer.Name, customer.Address, customer.IsActive
                ));
            _unitOfWork.CommitChanges();
        }

        public IEnumerable<CustomerDTO> GetActiveCustomers()
        {
            return _customerRepository.GetActiveCustomers()
                  .Select(c => new CustomerDTO()
                  {
                      Id= c.Id,
                      Name  = c.Name,
                      Address =c.Address,
                      IsActive = c.IsActive

                  });
        }

        public void UpdateCustomer(CustomerDTO customer)
        {
            _unitOfWork.Update(new Customer(customer.Id, customer.Name, customer.Address, customer.IsActive));
            _unitOfWork.CommitChanges();
        }
    }
}
