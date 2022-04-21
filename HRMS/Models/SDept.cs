using System.ComponentModel.DataAnnotations;

namespace HRMS.Models
{
    public class SDept
    {
        [Key]
        public int SDeptID { get; set; }

        public string SubDepartment { get; set; }

        public int DeptID { get; set; }
    }
}
