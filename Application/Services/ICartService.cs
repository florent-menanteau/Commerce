using AutoMapper;
using Commerce;
using Commerce.Infrastructure.DAO;
using Commerce.Infrastructure.Repositories;

namespace Application.Services
{
    public interface ICartService
    {
        decimal PriceCart(CartModel cart);
        Task<CartModel> CreateCartAsync(CartModel cart, CancellationToken cancellationToken);
        Task<IEnumerable<CartModel>> GetCustomerCartsAsync(long customerId, CancellationToken cancellationToken);
    }
}
