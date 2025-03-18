using Application;
using Application.Services;
using Commerce;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IPricingProvider, PricingProvider>();
            services.AddScoped<ICartPricer, CartPricer>();
            services.AddSingleton<ICartPricerFactory, CartPricerFactory>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
