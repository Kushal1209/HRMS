using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HRMS_Portal.Models
{
    public class Dept
    {
        [Key]
        [Required(ErrorMessage = "Enter Department")]
        public int DeptID { get; set; }

        [Required(ErrorMessage = "Enter Department")]
        public string Department { get; set; }

        [NotMapped]
        public int SDeptID { get; set; }
    }
}
