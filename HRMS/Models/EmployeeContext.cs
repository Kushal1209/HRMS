using HRMS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace HRMS_Portal.Models
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options):base(options)
        {
            
        }

        public DbSet<RequestModel> tbl_employeedetails { get; set; }

        public DbSet<BUnit> tbl_bunit { get; set; }

        public DbSet<Dept> tbl_dept { get; set; }

        public DbSet<RM> tbl_rm { get; set; }

        public DbSet<SDept> tbl_sdept { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);\\
        }
    }
}
