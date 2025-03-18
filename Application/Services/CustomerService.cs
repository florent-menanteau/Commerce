using AutoMapper;
using Commerce;
using Commerce.Infrastructure.DAO;
using Commerce.Infrastructure.Repositories;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public class CustomerService: ICustomerService
    {
        private readonly IMapper mapper;
        private readonly ILogger<CustomerService> logger;
        private readonly IRepository<Commerce.Infrastructure.DAO.Customer> repository;

        public CustomerService(IMapper mapper, ILogger<CustomerService> logger, IRepository<Commerce.Infrastructure.DAO.Customer> repository) 
        {
            this.mapper = mapper;
            this.logger = logger;
            this.repository = repository;
        }

        public async Task<Commerce.CustomerModel?> CreateCustomerAsync(string name, CancellationToken cancellationToken)
        {
            Commerce.CustomerModel customer = new Commerce.CustomerModel { Name = name };
            var result = await repository.CreateAsync(mapper.Map<Commerce.Infrastructure.DAO.Customer>(customer), cancellationToken);
            return mapper.Map<Commerce.CustomerModel?>(result);
        }

        public async Task<Commerce.CustomerModel?> GetAsync(long id, CancellationToken cancellationToken)
        {
            var result = await repository.GetAsync(id, cancellationToken);
            if (result == null) throw new ArgumentException($"{id}");
            return mapper.Map<Commerce.CustomerModel?>(result);
        }
    }
}
