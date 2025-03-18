using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public interface ICartPricerFactory
    {
        public ICartPricer Create();
    }
    public class CartPricerFactory : ICartPricerFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public CartPricerFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public ICartPricer Create()
        {
            return _serviceProvider.GetRequiredService<ICartPricer>();
        }
    }
}
