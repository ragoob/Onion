using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain
{
    public class Customer
    {
        public Customer()
        {

        }

        public Customer(string name ,string address,bool isActive)
        {
            this.Name = name;
            this.Address = address;
            this.IsActive = isActive;
        }

        public Customer(int id ,string name, string address, bool isActive)
        {
            this.Id = id;
            this.Name = name;
            this.Address = address;
            this.IsActive = isActive;
        }
        public int Id { get; private set; }

        public string Name { get; private set; }

        public string Address { get; private set; }

        public bool IsActive { get; private set; }

        
    }
}
