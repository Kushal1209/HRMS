using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HRMS.Models
{
    public class SDept
    {
        [Key]
        [Required(ErrorMessage = "Enter Sub-Department")]
        public int SDeptID { get; set; }

        [Required(ErrorMessage = "Enter Sub-Department")]
        public string SubDepartment { get; set; }

        [Required(ErrorMessage = "Enter Department")]
        public int DeptID { get; set; }
    }
}
