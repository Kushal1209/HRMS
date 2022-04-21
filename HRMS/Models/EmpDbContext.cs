using Microsoft.EntityFrameworkCore;

namespace HRMS.Data
{
    public class EmpDbContext:DbContext
    {
        public EmpDbContext(DbContextOptions<EmpDbContext> options) : base(options)
        {

        }

        public DbSet<HRMS.Models.RequestModel> tbl_employeedetails { get; set; }

        public DbSet<HRMS.Models.BUnit> tbl_bunit { get; set; }

        public DbSet<HRMS.Models.Dept> tbl_dept { get; set; }

        public DbSet<HRMS.Models.RM> tbl_rm { get; set; }

        public DbSet<HRMS.Models.SDept> tbl_sdept { get; set; }

        public DbSet<HRMS.Models.AssignOnBoardReq> tbl_assignonboardreq { get; set; }

        public DbSet<HRMS.Models.Assignee> tbl_assignee { get; set; }

        public DbSet<HRMS.Models.Tasks> tbl_tasks { get; set; }

        public DbSet<HRMS.Models.ListOfOnboardingEmp> tbl_listofemp { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);\\
        }
    }
}
