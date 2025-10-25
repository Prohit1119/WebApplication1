using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FoodDeliveryAppV1.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string CustomerName { get; set; }

        [Required,StringLength(50),EmailAddress]
        public string Email { get; set; }

        [Required,StringLength(255),DataType(DataType.Password)]
        public string password { get; set; }

        [StringLength(15)]
        public string PhoneNumber { get; set; }
        [StringLength(200)]
        public string Address { get; set; }

        public List<Order> Orders { get; set; }




    }
}
