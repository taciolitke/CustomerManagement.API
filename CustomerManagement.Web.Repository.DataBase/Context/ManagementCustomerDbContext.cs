using CustomerManagement.Web.Repository.DataBase.Configuration;
using CustomerManagement.Web.Repository.DataBase.Seed;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagement.Web.Repository.DataBase.Context
{
    public class ManagementCustomerDbContext: DbContext
    {
        public ManagementCustomerDbContext(DbContextOptions<ManagementCustomerDbContext> options) : base(options) => Database.EnsureCreated();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());

            modelBuilder.Seed();

            base.OnModelCreating(modelBuilder);
        }
       
    }
}
