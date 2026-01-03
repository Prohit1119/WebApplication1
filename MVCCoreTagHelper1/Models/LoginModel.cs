using System.ComponentModel.DataAnnotations;

namespace MVCCoreTagHelper1.Models
{
    public class LoginModel
    {
        [EmailAddress]
        public string? EmailAddress { get; set; }

        [DataType(DataType.Password)]
        public string? Password { get; set; }

        public bool? RememberMe { get; set; }
    }
}
