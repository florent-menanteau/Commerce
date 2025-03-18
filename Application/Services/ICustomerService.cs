using Commerce;

namespace Application.Services
{
    public interface ICustomerService
    {
        Task<CustomerModel?> CreateCustomerAsync(string name, CancellationToken cancellationToken);
        Task<CustomerModel?> GetAsync(long id, CancellationToken cancellationToken);

    }
}
