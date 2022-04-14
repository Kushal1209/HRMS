using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRMS_Portal.Migrations
{
    public partial class AddAssignTaskpages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeptID",
                table: "tbl_sdept",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "tbl_assignee",
                columns: table => new
                {
                    AssigneeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssigneeName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_assignee", x => x.AssigneeID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_assignonboardreq",
                columns: table => new
                {
                    AssignTaskID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskID = table.Column<int>(nullable: false),
                    AssigneeID = table.Column<int>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_assignonboardreq", x => x.AssignTaskID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_tasks",
                columns: table => new
                {
                    TaskID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_tasks", x => x.TaskID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_assignee");

            migrationBuilder.DropTable(
                name: "tbl_assignonboardreq");

            migrationBuilder.DropTable(
                name: "tbl_tasks");

            migrationBuilder.DropColumn(
                name: "DeptID",
                table: "tbl_sdept");
        }
    }
}
