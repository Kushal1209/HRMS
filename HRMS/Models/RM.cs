using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.Models
{
    public class RM
    {
        [Key]
        public int RMID { get; set; }

        public string ReportingManager { get; set; }
    }
}
