using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace LifeInsuranceApplication.Models.DTO
{
    public class UserCreateDTO
    {
        [Required(ErrorMessage = "Username cannot be empty")]
        public string Username { get; set; } = string.Empty;
        [Required(ErrorMessage = "Password cannot be empty")]

        [RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = "Password pattern worng")]
        [DefaultValue("password")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long")]
        public string Password { get; set; } = string.Empty;

        public Roles Roles { get; set; }
    }
}
