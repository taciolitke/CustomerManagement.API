using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagement.Web.API.Model.Login
{
    public class UserLoginResponse
    {
        public string Email { get; set; }
        public string Token { get; set; }
        public bool IsAdministrator { get; set; }
        public static UserLoginResponse Create(string email, string token, bool administrator) => new UserLoginResponse()
        {
            Email = email,
            Token = token,
            IsAdministrator = administrator
        };
    }
}
