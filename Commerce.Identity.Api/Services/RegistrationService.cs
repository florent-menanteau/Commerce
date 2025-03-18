using Commerce.Identity.Api.Database;
using Commerce.Identity.Api.Dto;
using Microsoft.AspNetCore.Identity;

namespace Commerce.Identity.Api.Services
{
    public interface IRegistrationService
    {
        Task<IdentityResult> RegisterAsync(UserRegistrationDto userRegistrationDto, CancellationToken cancellationToken);
    }

    public class RegistrationService:IRegistrationService
    {
        private readonly UserManager<User> userManager;
        private readonly ILogger<RegistrationService> logger;

        public RegistrationService(UserManager<User> userManager, ILogger<RegistrationService> logger)
        {
            this.userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IdentityResult> RegisterAsync(UserRegistrationDto userRegistrationDto, CancellationToken cancellationToken) {
            if (userRegistrationDto == null) return IdentityResult.Failed(new IdentityError { Description = "User was null" });

            var user = new User { Id = Guid.NewGuid().ToString(), Email = userRegistrationDto.Login, UserName = userRegistrationDto.Login, NormalizedUserName = userRegistrationDto.Login.ToUpper() };
            var result = await userManager.CreateAsync(user, userRegistrationDto.Password!);
            if (!result.Succeeded) return result;
            result = await userManager.AddToRoleAsync(user, "Customer");
            return result;
        }
    }
}
