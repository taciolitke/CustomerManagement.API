using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CustomerManagement.Web.API.Model.Customers;
using CustomerManagement.Web.API.Security;
using CustomerManagement.Web.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagement.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Bearer")]
    public class CustomerController : ControllerBase
    {

        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult Get([FromQuery]CustomerFilter customerFilter)
        {
            var currentUser = CurrentUser.Create(HttpContext);

            var filter = customerFilter.ToPredicate(currentUser);

            var customers = _customerService.GetAll(filter).Select(customer => CustomerModel.Create(customer));

            return Ok(new
            {
                success = true,
                data = customers
            });
        }
        [HttpGet("Count")]
        public IActionResult Get()
        {
            var currentUser = CurrentUser.Create(HttpContext);
            
            return Ok(new
            {
                success = true,
                data = _customerService.Count(x => (currentUser.IsAdministrator ? true : x.Seller.Email.Equals(currentUser.Email)))
        });
        }

        [HttpGet("Classifications")]
        public IActionResult GetClassifications()
        {
            var currentUser = CurrentUser.Create(HttpContext);

            var classifications = _customerService.GetAll(x => (currentUser.IsAdministrator ? true : x.Seller.Email.Equals(currentUser.Email))).Select(x => x.Classification).Distinct();

            return Ok(new
            {
                success = true,
                data = classifications
            });
        }
    }
}