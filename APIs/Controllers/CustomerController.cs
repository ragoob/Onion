using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationServices.CustomersService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpPost]
        public IActionResult Post(CustomerDTO model)
        {
            if (!model.IsVaild)
            {
                return BadRequest(model.Errors());
            }
            _customerService.CreateCustomer(model);
            return Ok(model);
        }

        [HttpPut]
        public IActionResult Put(CustomerDTO model)
        {
            if (!model.IsVaild)
            {
                return BadRequest(model.Errors());
            }
            _customerService.UpdateCustomer(model);
            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_customerService.GetActiveCustomers());
        }
    }
}