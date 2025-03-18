using Commerce.Infrastructure.DAO;

namespace Commerce.Infrastructure.Repositories
{
    public class CustomerRepository : GenericRepository<DAO.Customer>
    {
        public CustomerRepository(CommerceDbContext commerceDbContext):base(commerceDbContext) { }
    }
}
