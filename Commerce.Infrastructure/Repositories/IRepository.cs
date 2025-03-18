using Commerce.Infrastructure.DAO;

namespace Commerce.Infrastructure.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetAsync(long id, CancellationToken cancellationToken);

        Task<T?> CreateAsync(T entity, CancellationToken cancellationToken);
        Task<ICollection<T>?> CreateListAsync(ICollection<T> entity, CancellationToken cancellationToken);

        Task<int> UpdateAsync(T entity, CancellationToken cancellationToken);

        Task<int> DeleteAsync(T entity, CancellationToken cancellationToken);
    }
    public interface ICartRepository : IRepository<DAO.Cart>
    {
        Task<IEnumerable<DAO.Cart>> GetCustomerCartsAsync(long customerId, CancellationToken cancellationToken);
    }
}
