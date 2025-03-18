using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Commerce.Identity.Api.Database
{
    public interface IUserRepository
    {
        Task<User?> Get(string login);
    }
    public class UserRepository: IUserRepository
    {
        private readonly CommerceIdentityDbContext commerceIdentityDbContext;

        public UserRepository(CommerceIdentityDbContext commerceIdentityDbContext)
        {
            this.commerceIdentityDbContext = commerceIdentityDbContext;
        }
        public async Task<User?> Get(string login)
        {
            return await commerceIdentityDbContext.Set<User>().FirstOrDefaultAsync(u => u.Email == login);
        }
    }
}
