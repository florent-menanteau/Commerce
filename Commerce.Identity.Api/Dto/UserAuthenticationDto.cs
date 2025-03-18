using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Commerce.Identity.Api.Dto
{
    public class UserAuthenticationDto
    {
        [EmailAddress]
        [Required]
        public string? Login { get; set; }
        
        [PasswordPropertyText]
        [Required]
        public string? Password { get; set; }
    }
}
