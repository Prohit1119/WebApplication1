using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MVCWithEFCF2.Models
{
    [Table("Supplier")]  //specifiy name for creating of table in database
    public class Supplier
    {   
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Sid { get; set; }

        [MaxLength(100)]
        [Column("Sname" ,TypeName ="Varchar")]
        public string SupplierName { get; set; }

        public ICollection<Customer> Customers { get; set; }

    }

    



}