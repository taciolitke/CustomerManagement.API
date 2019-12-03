using CustomerManagement.Web.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CustomerManagement.Web.API.Security
{
    public class CurrentUser
    {
        public string Email { get; set; }

        public IEnumerable<Claim> Claims { get; set; }

        public bool IsAdministrator { 
            get
            {
                return Claims.Any(x => x.Type == ClaimTypes.Role && x.Value.Equals(Role.ADMINISTRATOR));
            }
        }

        public static CurrentUser Create(HttpContext httpContext) => new CurrentUser()
        {
            Email = httpContext.User.Identity.Name,
            Claims = GetClaims(httpContext),
        };

        private static IEnumerable<Claim> GetClaims(HttpContext httpContext)
        {

            var claims = new List<Claim>();

            var identity = httpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                claims.AddRange(identity.Claims);

            }
            return claims;
        }
    }
}
