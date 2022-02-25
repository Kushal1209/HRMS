using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using HRMS_Portal.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HRMS.Models
{
    public class RequestModel
    {
        [Key]
        public int EmpID { get; set; }

        [Required(ErrorMessage ="Enter Firstname!!")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Only letters are allowed!!")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Enter Lastname")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Only letters are allowed!!")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Enter Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter Mobile No.")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        [DataType(DataType.PhoneNumber)]
        public string Mobile { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Enter Date of Joining")]
        //[DisplayFormat(DataFormatString = "{0:DD/mm/yyyy}", ApplyFormatInEditMode = true)]
        [RegularExpression(@"(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$", ErrorMessage = "Invalid date format. It must be in dd/mm/yyyy")]
        public DateTime Doj { get; set; }

        [Required(ErrorMessage = "Enter Business Unit")]
        [Display(Name ="Business Unit")]
        public int BUnitID { get; set; }

        [Required(ErrorMessage = "Enter Department")]
        [Display(Name = "Department")]
        public int DeptID { get; set; }

        [Required(ErrorMessage = "Enter Sub-Department")]
        [Display(Name = "Sub-Department")]
        public int SDeptID { get; set; }

        [Required(ErrorMessage = "Enter Designation")]
        public string Designation { get; set; }

        [Required(ErrorMessage = "Enter Reporting Manager")]
        [Display(Name = "Reporting Manager")]
        public int RMID { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Enter Business Unit")]
        public string Businessunit { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Enter Department")]
        public string Department { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Enter Sub-Department")]
        [Display(Name = "Sub-Department")]
        public string SubDepartment { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Enter Reporting Manager")]
        public string ReportingManager { get; set; }
    }
}
