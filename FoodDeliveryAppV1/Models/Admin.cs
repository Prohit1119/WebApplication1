using System.Data.Common;
using System.ComponentModel.DataAnnotations;


namespace FoodDeliveryAppV1.Models
{
    public class Admin
    {
        //primary key
        [Key]
        public int AdminId { get; set; }

        //complusary not null
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required,StringLength(100),EmailAddress]
        public string Email { get; set; }

        [Required,StringLength (50)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [StringLength(50)]
        public string PhoneNumber { get; set; }

        [StringLength(50)]
        public string Role { get; set; }


    }
}
