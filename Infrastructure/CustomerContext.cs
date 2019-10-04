using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.SqlServer;
using Core.Domain;

namespace Infrastructure
{
    public class CustomerContext : DbContext
    {
        public CustomerContext() { }

        public CustomerContext(DbContextOptions<CustomerContext> dbContextOptions)
            : base(dbContextOptions) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=CustomersDb;User ID=sa; Password=P@ssw0rdroot77");
            }
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             modelBuilder.Entity<Customer>()
            .ToTable("Customers");
            modelBuilder.Entity<Customer>().HasKey(c => c.Id);


            base.OnModelCreating(modelBuilder);
        }
    }
}
