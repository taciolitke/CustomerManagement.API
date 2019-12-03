using CustomerManagement.Web.Domain.Entities;
using CustomerManagement.Web.Domain.Interfaces.Repositories;
using CustomerManagement.Web.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CustomerManagement.Web.Domain.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public IEnumerable<Customer> GetAll(Expression<Func<Customer, bool>> predicate)
        {
            return _customerRepository.GetAll(predicate);
        }
        public int Count(Expression<Func<Customer, bool>> predicate)
        {
            return _customerRepository.Count(predicate);
        }

    }
}
