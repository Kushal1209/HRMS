using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.Models
{
    public class AssignOnBoardReq
    {
        [Key]
        public int AssignTaskID { get; set; }

        [Required(ErrorMessage = "Enter Task")]
        [ForeignKey("TaskID")]
        public int TaskID { get; set; }

        [Required(ErrorMessage = "Select Assignee")]
        [ForeignKey("AssigneeID")]
        public int AssigneeID { get; set; }

        [Required(ErrorMessage = "Enter Due Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DueDate { get; set; }

        [Required(ErrorMessage = "Enter Task")]
        [NotMapped]
        [Display(Name = "Task Name")]
        public string TaskName { get; set; }

        [Required(ErrorMessage = "Enter Assignee")]
        [NotMapped]
        [Display(Name = "Assignee")]
        public string AssigneeName { get; set; }
    }
}
