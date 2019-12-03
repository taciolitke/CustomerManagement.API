using CustomerManagement.Web.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CustomerManagement.Web.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        User GetBy(Expression<Func<User, bool>> predicate);
        IEnumerable<User> GetAll(Expression<Func<User, bool>> predicate);
    }
}
