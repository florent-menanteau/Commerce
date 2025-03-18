using AutoMapper;
using Commerce;
using Commerce.Infrastructure.DAO;

namespace Application.Mappings
{
    public class CartProfile : Profile
    {
        public CartProfile() {
            CreateMap<CartModel, Cart>();
            CreateMap<Cart, CartModel>();
        }
    }
}
