using Application;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Commerce.Api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CartController(ILogger<CartController> logger, ICartService cartService) : Controller
    {
        [HttpGet("Index")]
        public IActionResult Index()
        {
            return Ok("Yo");
        }
        [HttpPost("Price")]
        public IActionResult PriceCart(CartModel cart)
        {
            decimal price = cartService.PriceCart(cart);
            return Ok(price);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateCart(CartModel cart, CancellationToken cancellationToken)
        {
            var c = await cartService.CreateCartAsync(cart, cancellationToken);
            return Ok(c);
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomerCart(long customerId, CancellationToken cancellationToken)
        {
            var res = await cartService.GetCustomerCartsAsync(customerId, cancellationToken);
            return Ok(res);
        }
    }
}
