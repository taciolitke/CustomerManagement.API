using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagement.Web.Domain.Interfaces.Services
{
    public interface IAutenticationService
    {
        bool CheckPasswordSignIn(string email, string password);
    }
}
