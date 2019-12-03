using CustomerManagement.Web.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagement.Web.Domain.Services
{
    public class AutenticationService: IAutenticationService
    {
        private readonly IUserService _userService;
        public AutenticationService(IUserService userService)
        {
            _userService = userService;
        }

        public bool CheckPasswordSignIn(string email, string password)
        {
            return _userService.GetBy(user => user.Email.Equals(email) && Md5Service.VerifyMd5Hash(password, user.Password)) != null;
        }
    }
}
