using Microsoft.EntityFrameworkCore.Migrations;

namespace AJE.Migrations
{
    public partial class _3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Prefets",
                newName: "PrefetID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Ecoles",
                newName: "EcoleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PrefetID",
                table: "Prefets",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "EcoleID",
                table: "Ecoles",
                newName: "ID");
        }
    }
}
