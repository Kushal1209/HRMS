using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS_Portal.Models
{
    public class ListofTask
    {
        [Key]
        public int TaskID { get; set; }

        [Required]  
        public string TaskName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DueDate { get; set; }
    }
}
