using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HRMS.Models
{
    public class Dept
    {
        [Key]
        public int DeptID { get; set; }

        public string Department { get; set; }

        [NotMapped]
        public int SDeptID { get; set; }
    }
}
