using Commerce;

namespace Application.Services
{
    public interface IProductService
    {
        Task<ProductModel> CreateProductAsync(ProductModel product, CancellationToken cancellationToken);
    }
}
