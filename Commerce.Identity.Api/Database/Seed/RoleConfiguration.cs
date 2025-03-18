using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Commerce.Identity.Api.Database.Seed
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(
                new Role
                {
                    Id = "5c28b074-7e58-44cc-b227-d7ed1d527cce",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new Role
                {
                    Id = "49f7b137-7f2f-42fc-be41-3dedd7896e0c",
                    Name = "Customer",
                    NormalizedName = "CUSTOMER"
                }
                );
        }
    }
}
