using System.ComponentModel.DataAnnotations;

namespace FoodDeliveryAppV1.ViewModel
{
    public class CustomerLoginViewModel
    {
        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(50)]
        public string Password { get; set; }
    }
}
