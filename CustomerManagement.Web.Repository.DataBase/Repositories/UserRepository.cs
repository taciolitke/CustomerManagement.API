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
    public class UserRepository: IUserRepository
    {
        protected readonly ManagementCustomerDbContext Db;
        protected readonly DbSet<User> DbSet;

        public UserRepository(ManagementCustomerDbContext context)
        {
            Db = context;
            DbSet = Db.Set<User>();
        }

        public User GetBy(Expression<Func<User, bool>> predicate)
        {
            return DbSet.Where(predicate).FirstOrDefault();
        }
        public IEnumerable<User> GetAll(Expression<Func<User, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }
    }
}
