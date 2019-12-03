using CustomerManagement.Web.Domain.Entities;
using CustomerManagement.Web.Domain.Interfaces.Repositories;
using CustomerManagement.Web.Repository.DataBase.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CustomerManagement.Web.Repository.DataBase.Repositories
{
    public class CustomerRepository: ICustomerRepository
    {
        protected readonly ManagementCustomerDbContext Db;
        protected readonly DbSet<Customer> DbSet;

        public CustomerRepository(ManagementCustomerDbContext context)
        {
            Db = context;
            DbSet = Db.Set<Customer>();
        }

        public int Count(Expression<Func<Customer, bool>> predicate)
        {
            return GetAll(predicate).Count();
        }

        public IEnumerable<Customer> GetAll() {
            return DbSet.Include(x => x.Seller);
        }

        public IEnumerable<Customer> GetAll(Expression<Func<Customer, bool>> predicate)
        {
            return DbSet.Where(predicate).Include(x => x.Seller);
        }
    }
}
