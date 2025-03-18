using Application.Dtos;
using AutoMapper;
using Commerce;
using Commerce.Infrastructure.DAO;

namespace Application.Mappings
{
    public class PricingStrategyProfile : Profile
    {
        public PricingStrategyProfile() {
            CreateMap<PricingDto, BundlePricingStrategie>();//.ForAllMembers(x => x.Condition(y => y.PricingType == PricingType.Bundle));
            CreateMap<PricingDto, UnitaryDiscountPricingStrategie>();//.ForAllMembers(x => x.Condition(y => y.PricingType == PricingType.Discount));
            CreateMap<PricingDto, UnitaryPricingStrategie>();//.ForAllMembers(x => x.Condition(y => y.PricingType == PricingType.Unitary));
            CreateMap<Customer, Customer>();
        }
    }
}
