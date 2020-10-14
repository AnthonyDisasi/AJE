using Microsoft.EntityFrameworkCore.Migrations;

namespace AJE.Migrations
{
    public partial class _init_1_ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "nom",
                table: "Ecoles",
                newName: "Nom");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nom",
                table: "Ecoles",
                newName: "nom");
        }
    }
}
