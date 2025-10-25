using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCWithEFCF4.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int Class { get; set; }
        [MaxLength(1)]
        [Column(TypeName ="Varchar")]
        public string section { get; set; }

        public float? Fees { get; set; }

    }
}