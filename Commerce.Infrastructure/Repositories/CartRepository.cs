using Commerce.Infrastructure.DAO;
using Microsoft.EntityFrameworkCore;

namespace Commerce.Infrastructure.Repositories
{
    public class CartRepository : GenericRepository<DAO.Cart>, ICartRepository
    {
        public CartRepository(CommerceDbContext context) : base(context) 
        { 
        }

        public async Task<IEnumerable<Cart>> GetCustomerCartsAsync(long customerId, CancellationToken cancellationToken)
        {
            return await (from c in commerceDbContext.Carts
                         where c.CustomerId == customerId
                         select c)
                         .Include(c => c.Items)
                         .ToListAsync(cancellationToken);
        }

    }
}
