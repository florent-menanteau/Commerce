using Commerce.Identity.Api.Database.Seed;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Commerce.Identity.Api.Database
{
    public class CommerceIdentityDbContext : IdentityDbContext<User, Role, string>
    {
        public CommerceIdentityDbContext(DbContextOptions<CommerceIdentityDbContext> options) : base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());
        }
    }
}
