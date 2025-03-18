using Commerce.Infrastructure.DAO;

namespace Commerce.Infrastructure.Repositories
{
    public interface ICustomerRepository
    {

        void CreateCustomerAsync(DAO.Customer customer, CancellationToken cancellationToken);

        void UpdateCustomerAsync(DAO.Customer customer, CancellationToken cancellationToken);

        void DeleteCustomerAsync(DAO.Customer customer, CancellationToken cancellationToken);
    }
}
