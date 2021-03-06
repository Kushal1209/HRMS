using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.Models
{
    public class RequestModel
    {
        [Key]
        public int EmpID { get; set; }

        [Required(ErrorMessage ="*Enter Firstname*")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Only letters are allowed!!")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "*Enter Lastname*")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Only letters are allowed!!")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "*Enter Email Address*")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "*Enter Mobile No.*")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "*Enter Date of Joining*")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Doj { get; set; }

        //[Required(ErrorMessage = "*Enter Business Unit*")]
        [ForeignKey("BUnitID")]
        [Display(Name ="Business Unit")]
        public int BUnitID { get; set; }

        //[Required(ErrorMessage = "*Enter Department*")]
        [ForeignKey("DeptID")]
        [Display(Name = "Department")]
        public int DeptID { get; set; }

        //[Required(ErrorMessage = "*Enter SubDepartment*")]
        [ForeignKey("SDeptID")]
        [Display(Name = "SubDepartment")]
        public int SDeptID { get; set; }

        [Required(ErrorMessage = "*Enter Designation*")]
        public string Designation { get; set; }

        //[Required(ErrorMessage = "*Enter Reporting Manager*")]
        [ForeignKey("RMID")]
        [Display(Name = "Reporting Manager")]
        public int RMID { get; set; }

        //[Required(ErrorMessage = "Enter Business Unit")]
        [NotMapped]
        public string Businessunit { get; set; }

        //[Required(ErrorMessage = "Enter Department")]
        [NotMapped]
        public string Department { get; set; }

        //[Required(ErrorMessage = "Enter Sub-Department")]
        [NotMapped]
        public string SubDepartment { get; set; }

        //[Required(ErrorMessage = "Enter Reporting Manager")]
        [NotMapped]
        public string ReportingManager { get; set; }
    }
}
