using Commerce.Identity.Api.Jwt;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;

namespace Commerce.Identity.Api.Tests
{
    public class JwtTokenHandlerTests
    {
        [Fact]
        public void NullUser_ShouldThrow()
        {
            //arrange
            var options = Options.Create<JwtSettings>(new JwtSettings { Audience = "Audience", Issuer = "Issuer", SecretKey = "azertyuiopqsdfghjklmwxcvbnazertyuiopqsdfghjklmwxcvbnazertyuiopqsdfghjklmwxcvbnazertyuiopqsdfghjklmwxcvbnazertyuiopqsdfghjklmwxcvbn" });
            var tokenHandler = new JwtTokenHandler(options);
            // act
            // assert
            Assert.Throws<ArgumentNullException>(() => tokenHandler.CreateToken(null, null, null));
        }

        [Fact]
        public void EmptySecretKey_ShouldThrow()
        {
            //arrange
            var options = Options.Create<JwtSettings>(new JwtSettings { Audience = "Audience", Issuer = "Issuer", SecretKey = "" });
            var tokenHandler = new JwtTokenHandler(options);
            // act
            // assert
            var exception = Assert.Throws<ArgumentException>(() => tokenHandler.CreateToken(new Database.User { UserName = "Test" }, null, null));
        }
        [Fact]
        public void TooShortSecretKey_ShouldThrow()
        {
            //arrange
            var options = Options.Create<JwtSettings>(new JwtSettings { Audience = "Audience", Issuer = "Issuer", SecretKey = "azer" });
            var tokenHandler = new JwtTokenHandler(options);
            // act
            // assert
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => tokenHandler.CreateToken(new Database.User { UserName = "Test" }, null, null));
        }
        [Fact]
        public void Should_CreateBasicUserToken()
        {
            //arrange
            var options = Options.Create<JwtSettings>(new JwtSettings { Audience = "Audience", Issuer = "Issuer", SecretKey = "azertyuiopqsdfghjklmwxcvbnazertyuiopqsdfghjklmwxcvbn" });
            var tokenHandler = new JwtTokenHandler(options);
            // act
            string token = tokenHandler.CreateToken(new Database.User { UserName = "Test" }, null, null, null, new DateTime(2010,1,1));
            // assert
            Assert.NotNull(token);
            var jwtSecurityToken = new JwtSecurityTokenHandler().ReadJwtToken(token);
            Assert.NotNull(jwtSecurityToken.Header);
            Assert.Equal(jwtSecurityToken.Header.Count(), 2);
            Assert.Equal(jwtSecurityToken.Header.ElementAt(0).Key, "alg");
            Assert.Equal(jwtSecurityToken.Header.ElementAt(0).Value, "HS256");
            Assert.Equal(jwtSecurityToken.Header.ElementAt(1).Key, "typ");
            Assert.Equal(jwtSecurityToken.Header.ElementAt(1).Value, "JWT");

            Assert.NotNull(jwtSecurityToken.Claims);
            Assert.Equal(jwtSecurityToken.Claims.Count(), 4);
            Assert.Equal(jwtSecurityToken.Claims.ElementAt(0).Type, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name");
            Assert.Equal(jwtSecurityToken.Claims.ElementAt(0).Value, "Test");
            Assert.Equal(jwtSecurityToken.Claims.ElementAt(1).Type, "exp");
            Assert.Equal(jwtSecurityToken.Claims.ElementAt(1).Value, "1262304000");
            Assert.Equal(jwtSecurityToken.Claims.ElementAt(2).Type, "iss");
            Assert.Equal(jwtSecurityToken.Claims.ElementAt(2).Value, options.Value.Issuer);
            Assert.Equal(jwtSecurityToken.Claims.ElementAt(3).Type, "aud");
            Assert.Equal(jwtSecurityToken.Claims.ElementAt(3).Value, options.Value.Audience);



            Assert.NotNull(jwtSecurityToken.Audiences);
            Assert.Equal(jwtSecurityToken.Audiences.Count(), 1);
            Assert.Equal(jwtSecurityToken.Audiences.ElementAt(0), options.Value.Audience);
            Assert.Equal(jwtSecurityToken.Issuer, options.Value.Issuer);
        }
        [Fact]
        public void Should_UserCreateToken_WithOneUserRole()
        {
            //arrange
            var options = Options.Create<JwtSettings>(new JwtSettings { Audience = "Audience", Issuer = "Issuer", SecretKey = "azertyuiopqsdfghjklmwxcvbnazertyuiopqsdfghjklmwxcvbn" });
            var tokenHandler = new JwtTokenHandler(options);
            // act
            string token = tokenHandler.CreateToken(new Database.User { UserName = "Test" }, new List<string> { "Admin" }, null, new List<System.Security.Claims.Claim> { new("CanOrder", "true") }, new DateTime(2010, 1, 1));
            // assert
            Assert.NotNull(token);
            var jwtSecurityToken = new JwtSecurityTokenHandler().ReadJwtToken(token);
            Assert.NotNull(jwtSecurityToken.Header);
            Assert.Equal(jwtSecurityToken.Header.Count(), 2);
            Assert.Equal(jwtSecurityToken.Header.ElementAt(0).Key, "alg");
            Assert.Equal(jwtSecurityToken.Header.ElementAt(0).Value, "HS256");
            Assert.Equal(jwtSecurityToken.Header.ElementAt(1).Key, "typ");
            Assert.Equal(jwtSecurityToken.Header.ElementAt(1).Value, "JWT");

            Assert.NotNull(jwtSecurityToken.Claims);
            Assert.Equal(jwtSecurityToken.Claims.Count(), 6);
            Assert.True(jwtSecurityToken.Claims.Any(c => c.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role" && c.Value == "Admin"));
            Assert.True(jwtSecurityToken.Claims.Any(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name" && c.Value == "Test"));
            Assert.True(jwtSecurityToken.Claims.Any(c => c.Type == "exp" && c.Value == "1262304000"));
            Assert.True(jwtSecurityToken.Claims.Any(c => c.Type == "iss" && c.Value == options.Value.Issuer));
            Assert.True(jwtSecurityToken.Claims.Any(c => c.Type == "aud" && c.Value == options.Value.Audience));
            Assert.True(jwtSecurityToken.Claims.Any(c => c.Type == "CanOrder" && c.Value == "true"));

            Assert.NotNull(jwtSecurityToken.Audiences);
            Assert.Equal(jwtSecurityToken.Audiences.Count(), 1);
            Assert.Equal(jwtSecurityToken.Audiences.ElementAt(0), options.Value.Audience);
            Assert.Equal(jwtSecurityToken.Issuer, options.Value.Issuer);
        }

        [Fact]
        public void Should_UserCreateToken_WithOneUserClaim()
        {
            //arrange
            var options = Options.Create<JwtSettings>(new JwtSettings { Audience = "Audience", Issuer = "Issuer", SecretKey = "azertyuiopqsdfghjklmwxcvbnazertyuiopqsdfghjklmwxcvbn" });
            var tokenHandler = new JwtTokenHandler(options);
            // act
            string token = tokenHandler.CreateToken(new Database.User { UserName = "Test" }, null, null, new List<System.Security.Claims.Claim> { new("CanOrder", "true") }, new DateTime(2010, 1, 1));
            // assert
            Assert.NotNull(token);
            var jwtSecurityToken = new JwtSecurityTokenHandler().ReadJwtToken(token);
            Assert.NotNull(jwtSecurityToken.Header);
            Assert.Equal(jwtSecurityToken.Header.Count(), 2);
            Assert.Equal(jwtSecurityToken.Header.ElementAt(0).Key, "alg");
            Assert.Equal(jwtSecurityToken.Header.ElementAt(0).Value, "HS256");
            Assert.Equal(jwtSecurityToken.Header.ElementAt(1).Key, "typ");
            Assert.Equal(jwtSecurityToken.Header.ElementAt(1).Value, "JWT");

            Assert.NotNull(jwtSecurityToken.Claims);
            Assert.Equal(jwtSecurityToken.Claims.Count(), 5);
            Assert.True(jwtSecurityToken.Claims.Any(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name" && c.Value == "Test"));
            Assert.True(jwtSecurityToken.Claims.Any(c => c.Type == "exp" && c.Value == "1262304000"));
            Assert.True(jwtSecurityToken.Claims.Any(c => c.Type == "iss" && c.Value == options.Value.Issuer));
            Assert.True(jwtSecurityToken.Claims.Any(c => c.Type == "aud" && c.Value == options.Value.Audience));
            Assert.True(jwtSecurityToken.Claims.Any(c => c.Type == "CanOrder" && c.Value == "true"));
        }

        [Fact]
        public void Should_UserCreateToken_WithTwoUserClaims()
        {
            //arrange
            var options = Options.Create<JwtSettings>(new JwtSettings { Audience = "Audience", Issuer = "Issuer", SecretKey = "azertyuiopqsdfghjklmwxcvbnazertyuiopqsdfghjklmwxcvbn" });
            var tokenHandler = new JwtTokenHandler(options);
            // act
            string token = tokenHandler.CreateToken(new Database.User { UserName = "Test" }, null, null, new List<System.Security.Claims.Claim> { new("CanOrder", "true"), new("CanCancel", "true") }, new DateTime(2010, 1, 1));
            // assert
            Assert.NotNull(token);
            var jwtSecurityToken = new JwtSecurityTokenHandler().ReadJwtToken(token);
            Assert.NotNull(jwtSecurityToken.Header);
            Assert.Equal(jwtSecurityToken.Header.Count(), 2);
            Assert.Equal(jwtSecurityToken.Header.ElementAt(0).Key, "alg");
            Assert.Equal(jwtSecurityToken.Header.ElementAt(0).Value, "HS256");
            Assert.Equal(jwtSecurityToken.Header.ElementAt(1).Key, "typ");
            Assert.Equal(jwtSecurityToken.Header.ElementAt(1).Value, "JWT");

            Assert.NotNull(jwtSecurityToken.Claims);
            Assert.Equal(jwtSecurityToken.Claims.Count(), 6);
            Assert.True(jwtSecurityToken.Claims.Any(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name" && c.Value == "Test"));
            Assert.True(jwtSecurityToken.Claims.Any(c => c.Type == "exp" && c.Value == "1262304000"));
            Assert.True(jwtSecurityToken.Claims.Any(c => c.Type == "iss" && c.Value == options.Value.Issuer));
            Assert.True(jwtSecurityToken.Claims.Any(c => c.Type == "aud" && c.Value == options.Value.Audience));
            Assert.True(jwtSecurityToken.Claims.Any(c => c.Type == "CanOrder" && c.Value == "true"));
            Assert.True(jwtSecurityToken.Claims.Any(c => c.Type == "CanCancel" && c.Value == "true"));
        }
    }
}