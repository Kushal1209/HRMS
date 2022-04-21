using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.Models
{
    public class ListOfOnboardingEmp
    {
        [Key]
        public int ListofEmpID { get; set; }

        [ForeignKey("EmpID")]
        public int EmpID { get; set; }

        [Display(Name = "Created By")]
        public int CreatedByID { get; set; }

        [NotMapped]
        [Display(Name = "First Name")]
        public string Firstname { get; set; }

        [NotMapped]
        [Display(Name = "Last Name")]
        public string Lastname { get; set; }

        [NotMapped]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [NotMapped]
        [Display(Name = "Business Unit")]
        public int BUnitID { get; set; }
    }
}
