using CustomerManagement.Web.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CustomerManagement.Web.Domain.Interfaces.Services
{
    public interface IUserService
    {
        User GetBy(Expression<Func<User, bool>> predicate);
        IEnumerable<User> GetAll(Expression<Func<User, bool>> predicate);
    }
}
