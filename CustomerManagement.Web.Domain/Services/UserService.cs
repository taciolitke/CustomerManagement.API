using CustomerManagement.Web.Domain.Entities;
using CustomerManagement.Web.Domain.Interfaces.Repositories;
using CustomerManagement.Web.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CustomerManagement.Web.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User GetBy(Expression<Func<User, bool>> predicate)
        {
            return _userRepository.GetBy(predicate);
        }
        public IEnumerable<User> GetAll(Expression<Func<User, bool>> predicate)
        {
            return _userRepository.GetAll(predicate);
        }
    }
}
