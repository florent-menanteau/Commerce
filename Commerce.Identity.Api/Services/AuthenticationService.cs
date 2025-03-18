using Commerce.Identity.Api.Database;
using Commerce.Identity.Api.Dto;
using Commerce.Identity.Api.Jwt;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Data;
using System.Security.Claims;

namespace Commerce.Identity.Api.Services
{
    public interface IAuthenticationService
    {
        Task<string> AuthenticateAsync(UserAuthenticationDto userAuthenticationDto, CancellationToken cancellationToken);
    }

        public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;
        private readonly ILogger<RegistrationService> logger;
        private readonly IJwtTokenHandler jwtTokenHandler;

        public AuthenticationService(UserManager<User> userManager, RoleManager<Role> roleManager, ILogger<RegistrationService> logger, IJwtTokenHandler jwtTokenHandler)
        {
            this.userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            this.roleManager = roleManager ?? throw new ArgumentNullException(nameof(roleManager));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.jwtTokenHandler = jwtTokenHandler ?? throw new ArgumentNullException(nameof(jwtTokenHandler));
        }

        public async Task<string> AuthenticateAsync(UserAuthenticationDto userAuthenticationDto, CancellationToken cancellationToken) {
            var user = await userManager.FindByEmailAsync(userAuthenticationDto.Login!);
            if (user is null || !await userManager.CheckPasswordAsync(user, userAuthenticationDto.Password!))
            {
                throw new UnauthorizedAccessException();
            }

            List<Claim> claims = new List<Claim>();

            var userClaims = await userManager.GetClaimsAsync(user);
            if(userClaims != null)
                claims.AddRange(userClaims);

            var roles = await userManager.GetRolesAsync(user);

            foreach (var roleName in roles)
            {
                var role = await roleManager.FindByNameAsync(roleName);
                if (role == null) continue;

                var roleClaims = await roleManager.GetClaimsAsync(role);
                if (roleClaims != null)
                    claims.AddRange(roleClaims);
            }
            var token = jwtTokenHandler.CreateToken(user, roles, claims, null, DateTime.UtcNow);
            return token;
        }
    }
}
