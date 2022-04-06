using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS_Portal.Models
{
    public class Assignee
    {
        [Required]
        [Key]
        public int AssigneeID { get; set; }

        [Required]
        public string AssigneeName { get; set; }
    }
}
