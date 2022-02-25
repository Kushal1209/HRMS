using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRMS_Portal.Migrations
{
    public partial class createDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_bunit",
                columns: table => new
                {
                    BUnitID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Businessunit = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_bunit", x => x.BUnitID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_dept",
                columns: table => new
                {
                    DeptID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Department = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_dept", x => x.DeptID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_employeedetails",
                columns: table => new
                {
                    EmpID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(nullable: false),
                    Lastname = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Mobile = table.Column<string>(nullable: false),
                    Doj = table.Column<DateTime>(nullable: false),
                    BUnitID = table.Column<int>(nullable: false),
                    DeptID = table.Column<int>(nullable: false),
                    SDeptID = table.Column<int>(nullable: false),
                    Designation = table.Column<string>(nullable: false),
                    RMID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_employeedetails", x => x.EmpID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_rm",
                columns: table => new
                {
                    RMID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportingManager = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_rm", x => x.RMID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_sdept",
                columns: table => new
                {
                    SDeptID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubDepartment = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_sdept", x => x.SDeptID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_bunit");

            migrationBuilder.DropTable(
                name: "tbl_dept");

            migrationBuilder.DropTable(
                name: "tbl_employeedetails");

            migrationBuilder.DropTable(
                name: "tbl_rm");

            migrationBuilder.DropTable(
                name: "tbl_sdept");
        }
    }
}
