using CustomerManagement.Web.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CustomerManagement.Web.Domain.Interfaces.Services
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAll(Expression<Func<Customer, bool>> predicate);

        int Count(Expression<Func<Customer, bool>> predicate);
    }
}
