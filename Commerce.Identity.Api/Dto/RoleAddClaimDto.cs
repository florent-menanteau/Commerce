using System.ComponentModel.DataAnnotations;

namespace Commerce.Identity.Api.Dto
{
    public class RoleAddClaimDto
    {
        [Required]
        public string RoleName { get; set; }
        [Required]
        public string ClaimName { get; set; }
        [Required]
        public string ClaimValue { get; set; }
    }
}
