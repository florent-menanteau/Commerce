using AutoMapper;
using Commerce;
using Commerce.Infrastructure.DAO;
using Commerce.Infrastructure.Repositories;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper mapper;
        private readonly ILogger<ProductService> logger;
        private readonly IRepository<Commerce.Infrastructure.DAO.Product> repository;

        public ProductService(IMapper mapper, ILogger<ProductService> logger, IRepository<Commerce.Infrastructure.DAO.Product> repository) 
        {
            this.mapper = mapper;
            this.logger = logger;
            this.repository = repository;
        }

        public async Task<Commerce.ProductModel> CreateProductAsync(Commerce.ProductModel product, CancellationToken cancellationToken)
        {
            product.Id = null;
            var res  = await repository.CreateAsync(mapper.Map<Product>(product), cancellationToken);
            return mapper.Map<Commerce.ProductModel>(res);
        }
    }
}
