using AutoMapper;
using Commerce;
using Commerce.Infrastructure.DAO;

namespace Application.Mappings
{
    public class CartItemProfile : Profile
    {
        public CartItemProfile() {
            CreateMap<CartItemModel, CartItem>();
            CreateMap<CartItem, CartItemModel>();
        }
    }
}
