using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Commerce.Identity.Api.Database.Seed
{
    //public class UserClaimConfiguration : IEntityTypeConfiguration<IdentityRoleClaim<string>>
    //{
    //    public void Configure(EntityTypeBuilder<IdentityRoleClaim<string>> builder)
    //    {
    //        builder.HasData(
    //            )
    //    }
    //}

    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    UserId = "832ef1f6-9396-43e9-9256-ff5f4ee4fac1",
                    RoleId = "5c28b074-7e58-44cc-b227-d7ed1d527cce"
                });
        }
    }

}
