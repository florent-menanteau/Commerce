using Commerce.Identity.Api.Database;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Commerce.Identity.Api.Jwt
{
    public interface IJwtTokenHandler
    {
        string CreateToken(User user, IList<string> roles, IList<Claim>? addclaims = null, IList<Claim>? userClaims = null, DateTime? date = null);
    }

    public class JwtTokenHandler:IJwtTokenHandler
    {
        private readonly IOptions<JwtSettings> options;

        public JwtTokenHandler(IOptions<JwtSettings> options)
        {
            this.options = options ?? throw new ArgumentNullException(nameof(options));
        }

        public string CreateToken(User user, IList<string> roles, IList<Claim>? addclaims = null, IList<Claim>? userClaims = null, DateTime? date = null)
        {
            if(user == null) throw new ArgumentNullException(nameof(user));

            var tokenHandler = new JwtSecurityTokenHandler();

            var claims = GetClaims(user, roles);
            if (addclaims is not null)
                claims = addclaims.Concat(claims).ToList();
            if (userClaims is not null)
                claims = userClaims.Concat(claims).ToList();
            int expiry = options.Value.ExpiryIn ?? 60;
            
            var securityTokenDescriptor = new JwtSecurityToken
            (
                claims: claims,
                expires: date.HasValue?date.Value.AddMinutes(expiry):DateTime.UtcNow.AddMinutes(expiry),
                audience: options.Value.Audience,
                issuer: options.Value.Issuer,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.Value.SecretKey)), SecurityAlgorithms.HmacSha256)
            );

            return tokenHandler.WriteToken(securityTokenDescriptor);
        }

        private IList<Claim> GetClaims(User user, IList<string> roles) {
            var claims = new List<Claim>()
            {
                new(ClaimTypes.Name, user.UserName!)
            };
            if (roles != null)
            {
                foreach (var role in roles)
                {
                    claims.Add(new(ClaimTypes.Role, role));
                }
            }
            return claims;
        }
    }
}
