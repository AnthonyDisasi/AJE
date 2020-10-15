using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AJE.Migrations
{
    public partial class _init_6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Epreuves_Bulletins_BulletinID",
                table: "Epreuves");

            migrationBuilder.DropTable(
                name: "Bulletins");

            migrationBuilder.DropIndex(
                name: "IX_Epreuves_BulletinID",
                table: "Epreuves");

            migrationBuilder.DropColumn(
                name: "BulletinID",
                table: "Epreuves");

            migrationBuilder.RenameColumn(
                name: "point",
                table: "Epreuves",
                newName: "Point");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Point",
                table: "Epreuves",
                newName: "point");

            migrationBuilder.AddColumn<int>(
                name: "BulletinID",
                table: "Epreuves",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Bulletins",
                columns: table => new
                {
                    BulletinID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AnneeScolaire = table.Column<DateTime>(nullable: false),
                    Application = table.Column<string>(nullable: true),
                    Mention = table.Column<string>(nullable: true),
                    Pourcentage = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bulletins", x => x.BulletinID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Epreuves_BulletinID",
                table: "Epreuves",
                column: "BulletinID");

            migrationBuilder.AddForeignKey(
                name: "FK_Epreuves_Bulletins_BulletinID",
                table: "Epreuves",
                column: "BulletinID",
                principalTable: "Bulletins",
                principalColumn: "BulletinID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
