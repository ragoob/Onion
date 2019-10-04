using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CustomerContext _customerContext;
        public UnitOfWork(CustomerContext customerContext)
        {
            _customerContext = customerContext;
        }
        public void CommitChanges()
        {
            _customerContext.SaveChanges();
        }

        public void Update<T>(T entity)
        {
            _customerContext.Update(entity);
        }
    }
}
