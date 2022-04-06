using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using HRMS.Models;
using HRMS_Portal.Models;
using System.Configuration;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HRMS.Models
{
    public class AssignTaskModel
    {
        [Key]
        public int AssignTaskID { get; set; }

        [Required]
        [ForeignKey("EmpID")]
        public int EmpID { get; set; }

        [Required]
        [ForeignKey("TaskID")]
        public int TaskID { get; set; }

        [Required]
        [ForeignKey("AssigneeID")]
        public int AssigneeID { get; set; }

        [NotMapped]
        [Required(ErrorMessage ="Enter Due Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DueDate { get; set; }

        [Required]
        [NotMapped]
        [Display(Name = "Name")]
        public string TaskName { get; set; }

        [Required]
        [NotMapped]
        [Display(Name = "Assignee")]
        public string AssigneeName { get; set; }
    }
}
