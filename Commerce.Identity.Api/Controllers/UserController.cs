using Commerce.Identity.Api.Database;
using Commerce.Identity.Api.Dto;
using Commerce.Identity.Api.Jwt;
using Commerce.Identity.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;

namespace Commerce.Identity.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;
        private readonly IRegistrationService registrationService;
        private readonly IAuthenticationService authenticationService;
        private readonly IJwtTokenHandler jwtTokenHandler;

        public UserController(UserManager<User> userManager, RoleManager<Role> roleManager,IRegistrationService registrationService, IAuthenticationService authenticationService, IJwtTokenHandler jwtTokenHandler)
        {
            this.userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            this.roleManager = roleManager ?? throw new ArgumentNullException(nameof(roleManager));
            this.registrationService = registrationService ?? throw new ArgumentNullException(nameof(registrationService));
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
            this.jwtTokenHandler = jwtTokenHandler ?? throw new ArgumentNullException(nameof(jwtTokenHandler));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser(UserRegistrationDto userRegistrationDto, CancellationToken cancellationToken)
        {
            if (userRegistrationDto is null)
                return BadRequest();

            var result = await registrationService.RegisterAsync(userRegistrationDto, cancellationToken);

            if(!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                return BadRequest(errors);
            }

            return StatusCode((int)HttpStatusCode.Created);
        }

        [Authorize(Policy = "AssignRolePolicy")]
        [HttpPost("AssignRole")]
        public async Task<IActionResult> AssignRole(UserRoleDto userRoleDto)
        {
            if (userRoleDto is null)
                return BadRequest();

            var role = await roleManager.FindByNameAsync(userRoleDto.RoleName);
            var user = await userManager.FindByEmailAsync(userRoleDto.Login);

            if (role == null)
                return BadRequest();
            if(user ==  null)
                return BadRequest();
            var result = await userManager.AddToRoleAsync(user, role.Name!);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                return BadRequest(errors);
            }

            return Ok();
        }


        [HttpPost("Auhenticate")]
        public async Task<IActionResult> Auhenticate(UserAuthenticationDto userAuthenticationDto, CancellationToken cancellationToken)
        {
            if (userAuthenticationDto is null)
                return BadRequest();

            var token = await authenticationService.AuthenticateAsync(userAuthenticationDto, cancellationToken);

            return Ok(token);
        }

        [Authorize(Policy ="CreateRolePolicy")]
        [HttpPost("CreateRole")]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName))
                return BadRequest();
            Role role = new Role
            {
                Id = Guid.NewGuid().ToString(),
                Name = roleName,
            };
            var result = await roleManager.CreateAsync(role);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                return BadRequest(errors);
            }

            return StatusCode((int)HttpStatusCode.Created);
        }


        //[Authorize(Policy = "AddRoleClaimPolicy")]
        [HttpPost("AssingClaimToRole")]
        public async Task<IActionResult> AssingClaimToRole(RoleAddClaimDto roleAddClaimDto)
        {
            if (roleAddClaimDto is null)
                return BadRequest();
            
            var role = await roleManager.FindByNameAsync(roleAddClaimDto.RoleName);
            if (role is null)
            {
                return BadRequest();
            }

            var result = await roleManager.AddClaimAsync(role, new System.Security.Claims.Claim(roleAddClaimDto.ClaimName, roleAddClaimDto.ClaimValue));
            
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                return BadRequest(errors);
            }

            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpGet("GetUser")]
        public async Task<IActionResult> GetUser(string login)
        {
            var user = await userManager.FindByEmailAsync(login);
            var roles  = await userManager.GetRolesAsync(user!);
            return Ok(user);
        }
    }
}
