using Application;
using Application.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Commerce.Api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CommerceController(ICartPricer cartPricer, IPricingProvider pricingProvider, IMapper mapper) : Controller
    {
        [HttpGet("Index")]
        public IActionResult Index()
        {
            return Ok("Yo");
        }
        [HttpPost("AddPricingModel")]
        public IActionResult AddPricingModel(PricingDto pricingModel)
        {
            IPricingStrategie pricingStrategie = null;

            switch (pricingModel.PricingType)
            {
                case PricingType.Unitary: pricingStrategie = new UnitaryPricingStrategie(pricingModel.ProductId, pricingModel.Price);
                    break;
                case PricingType.Discount:
                    pricingStrategie = new UnitaryDiscountPricingStrategie(pricingModel.ProductId,pricingModel.Price, pricingModel.Discount);
                    break;
                case PricingType.Bundle:
                    pricingStrategie = new BundlePricingStrategie(pricingModel.ProductId, pricingModel.Size, pricingModel.Price);
                    break;
                default: return BadRequest($"Unknow pricing type {pricingModel.PricingType}");
            }
            pricingProvider.AddPricingModel(pricingStrategie);

            return Ok(pricingProvider.GetPricingConfiguration());
        }

        [HttpGet("PricingModels")]
        public IActionResult GetList()
        {

            return Ok(pricingProvider.GetPricingConfiguration());
        }
    }
}
