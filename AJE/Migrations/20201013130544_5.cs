using Microsoft.EntityFrameworkCore.Migrations;

namespace AJE.Migrations
{
    public partial class _5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cours_Classes_ClasseID",
                table: "Cours");

            migrationBuilder.AlterColumn<int>(
                name: "ClasseID",
                table: "Cours",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cours_Classes_ClasseID",
                table: "Cours",
                column: "ClasseID",
                principalTable: "Classes",
                principalColumn: "ClasseID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cours_Classes_ClasseID",
                table: "Cours");

            migrationBuilder.AlterColumn<int>(
                name: "ClasseID",
                table: "Cours",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Cours_Classes_ClasseID",
                table: "Cours",
                column: "ClasseID",
                principalTable: "Classes",
                principalColumn: "ClasseID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
