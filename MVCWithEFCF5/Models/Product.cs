using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCWithEFCF5.Models
{
    public class Product
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int Class { get; set; }

        [MaxLength(1)]
        [Column(TypeName = "Varchar")]
        public string Section { get; set; }

        public float? Fees { get; set; }
    }
}