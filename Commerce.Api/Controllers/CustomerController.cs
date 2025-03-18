using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Commerce.Api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CustomerController(ILogger<CustomerController> logger, ICustomerService customerService) : Controller
    {
        [Authorize(Roles = "Admin")]
        [HttpPost("Create")]
        public async Task<IActionResult> CreateCustomer(string name, CancellationToken cancellationToken)
        {
            var customer = await customerService.CreateCustomerAsync(name, cancellationToken);
            return Ok(customer);
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomer(long id, CancellationToken cancellationToken)
        {
            var customer = await customerService.GetAsync(id, cancellationToken);

            if(customer == null) return NotFound($"{id}");

            return Ok(customer);
        }
    }
}
