using Commerce.Infrastructure;
using Commerce.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class Dependencies
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CommerceDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("Default")));
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ICartRepository, CartRepository>();
            return services;
        }
    }
}
