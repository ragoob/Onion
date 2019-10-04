using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
   public interface IUnitOfWork
    {
        void CommitChanges();

        void Update<T>(T entity);
    }
}
