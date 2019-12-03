using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerManagement.Web.API.Model.Login;
using CustomerManagement.Web.API.Security;
using CustomerManagement.Web.Domain.Entities;
using CustomerManagement.Web.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomarManagement.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize("Bearer")]
        [HttpGet("isLogged")]
        public IActionResult isLogged()
        {
            return Ok(new
            {
                success = true,
            });
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Post(
           [FromBody]UserLoginRequest user,
           [FromServices]AccessManager accessManager)
        {
            if (accessManager.ValidateCredentials(user))
            {
                var token = accessManager.GenerateToken(user).AccessToken;
                var userInfo = _userService.GetBy(x => x.Email.Equals(user.Email));

                var userResponse = UserLoginResponse.Create(user.Email, token, userInfo.Role.Equals(Role.ADMINISTRATOR));

                return Ok(new
                {
                    success = true,
                    data = userResponse
                });
            }
            else
            {
                return Ok(new
                {
                    success = false,
                    message = "The email and / or password entered is invalid.Please try again."
                });
            }
        }
    }
}