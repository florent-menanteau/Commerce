using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Commerce.Identity.Api.Dto
{
    public class UserRoleDto
    {
        [EmailAddress]
        [Required]
        public string Login { get; set; }
        
        [PasswordPropertyText]
        [Required]
        public string RoleName { get; set; }
    }
}
