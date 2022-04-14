using System.ComponentModel.DataAnnotations;

namespace HRMS.Models
{
    public class Tasks
    {
        [Key]
        public int TaskID { get; set; }

        [Required]
        public string TaskName { get; set; }
    }
}
