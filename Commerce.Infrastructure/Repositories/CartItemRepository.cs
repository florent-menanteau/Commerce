using Commerce.Infrastructure.DAO;

namespace Commerce.Infrastructure.Repositories
{
    public class CartItemRepository : GenericRepository<CartItem>
    {
        public CartItemRepository(CommerceDbContext context) : base(context) 
        { 
        }
    }
}
