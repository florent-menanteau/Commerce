using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Commerce.Identity.Api.Dto
{
    public class UserRegistrationDto
    {
        [EmailAddress]
        [Required]
        public string Login { get; set; }

        [Required]
        [PasswordPropertyText]
        public string Password { get; set; }
    }
}
