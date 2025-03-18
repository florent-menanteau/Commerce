using Application;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Commerce.Api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ProductController(ILogger<ProductController> logger, IProductService productService) : Controller
    {
        [HttpGet("Index")]
        public IActionResult Index()
        {
            return Ok("Yo");
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateProduct(ProductModel product, CancellationToken cancellationToken)
        {
            var c = await productService.CreateProductAsync(product, cancellationToken);
            return Ok(c);
        }
    }
}
