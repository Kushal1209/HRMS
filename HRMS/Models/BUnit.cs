using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.Models
{
    public class BUnit
    {
        [Key]
        public int BUnitID { get; set; }

        public string Businessunit { get; set; }
    }
}
