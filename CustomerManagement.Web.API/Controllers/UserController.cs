using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerManagement.Web.Domain.Entities;
using CustomerManagement.Web.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagement.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Bearer")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userrService;

        public UserController(IUserService userrService)
        {
            _userrService = userrService;
        }

        [HttpGet("Sellers")]
        public IActionResult Get()
        {
            var sellers = _userrService.GetAll(x => x.Role == Role.SELLER).Select(x => x.Name);

            return Ok(new
            {
                success = true,
                data = sellers
            });
        }
    }
}