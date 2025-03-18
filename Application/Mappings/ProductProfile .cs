using AutoMapper;
using Commerce;
using Commerce.Infrastructure.DAO;

namespace Application.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile() {
            CreateMap<ProductModel, Product>();
            CreateMap<Product, ProductModel>();
        }
    }
}
