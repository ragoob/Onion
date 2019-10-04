using ApplicationServices.CustomersService;
using Core;
using Core.Domain;
using Core.Repositories;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace ServiceTest
{
    [TestClass]
    public class CustomerServiceTest
    {
        private Mock<IUnitOfWork> unitofWork;
        
        public CustomerServiceTest()
        {
            unitofWork = new Mock<IUnitOfWork>();
            
        }

        [TestMethod]
        public void TestGetActiveCustomers()
        {
            var customers =new CustomerService(new CustomerRepository(GetQueryableMockDbSet(InitCustomer())), unitofWork.Object).GetActiveCustomers();

            Assert.IsFalse(customers.Any(c=> !c.IsActive)
                , "GetActiveCustomers faild to get correct data"
                );
        }

        



        private List<Customer> InitCustomer()
        {
            var List = new List<Customer>();
            List.Add(new Customer(1, "ahmed", "cairo", true));
            List.Add(new Customer(1, "ali", "giza", true));
            List.Add(new Customer(1, "khaled", "alex", false));
            return List;
        }



        private DbSet<Customer> GetQueryableMockDbSet(List<Customer> sourceList) 
        {
            var queryable = sourceList.AsQueryable();

            var dbSet = new Mock<DbSet<Customer>>();
            dbSet.As<IQueryable<Customer>>().Setup(m => m.Provider).Returns(queryable.Provider);
            dbSet.As<IQueryable<Customer>>().Setup(m => m.Expression).Returns(queryable.Expression);
            dbSet.As<IQueryable<Customer>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            dbSet.As<IQueryable<Customer>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());
            dbSet.Setup(d => d.Add(It.IsAny<Customer>())).Callback<Customer>((s) => sourceList.Add(s));

            return dbSet.Object;
        }
    }
}
