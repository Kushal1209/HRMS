using Microsoft.EntityFrameworkCore.Migrations;

namespace HRMS_Portal.Migrations
{
    public partial class ListOfEmp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_listofemp",
                columns: table => new
                {
                    ListofEmpID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpID = table.Column<int>(nullable: false),
                    CreatedByID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_listofemp", x => x.ListofEmpID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_listofemp");
        }
    }
}
