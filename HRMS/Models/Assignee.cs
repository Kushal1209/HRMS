using System.ComponentModel.DataAnnotations;

namespace HRMS.Models
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
