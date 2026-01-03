using System.ComponentModel.DataAnnotations;
namespace MVCCoreTagHelpers1.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        
        public string? Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
