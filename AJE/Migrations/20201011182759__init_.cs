using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AJE.Migrations
{
    public partial class _init_ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bulletins",
                columns: table => new
                {
                    BulletinID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AnneeScolaire = table.Column<DateTime>(nullable: false),
                    Pourcentage = table.Column<double>(nullable: false),
                    Mention = table.Column<string>(nullable: true),
                    Application = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bulletins", x => x.BulletinID);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategorieID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategorieID);
                });

            migrationBuilder.CreateTable(
                name: "Eleves",
                columns: table => new
                {
                    EleveID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(maxLength: 20, nullable: false),
                    Postnom = table.Column<string>(maxLength: 20, nullable: false),
                    Prenom = table.Column<string>(maxLength: 20, nullable: false),
                    Genre = table.Column<int>(nullable: false),
                    DateNaissance = table.Column<DateTime>(nullable: false),
                    Matricule = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eleves", x => x.EleveID);
                });

            migrationBuilder.CreateTable(
                name: "Inspecteurs",
                columns: table => new
                {
                    InspecteurID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(maxLength: 20, nullable: false),
                    Postnom = table.Column<string>(maxLength: 20, nullable: false),
                    Prenom = table.Column<string>(maxLength: 20, nullable: false),
                    Genre = table.Column<int>(nullable: false),
                    DateNaissance = table.Column<DateTime>(nullable: false),
                    Matricule = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inspecteurs", x => x.InspecteurID);
                });

            migrationBuilder.CreateTable(
                name: "Options",
                columns: table => new
                {
                    OptionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.OptionID);
                });

            migrationBuilder.CreateTable(
                name: "Prefets",
                columns: table => new
                {
                    PrefetID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(maxLength: 20, nullable: false),
                    Postnom = table.Column<string>(maxLength: 20, nullable: false),
                    Prenom = table.Column<string>(maxLength: 20, nullable: false),
                    Genre = table.Column<int>(nullable: false),
                    DateNaissance = table.Column<DateTime>(nullable: false),
                    Matricule = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prefets", x => x.PrefetID);
                });

            migrationBuilder.CreateTable(
                name: "Professeurs",
                columns: table => new
                {
                    ProfesseurID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(maxLength: 20, nullable: false),
                    Postnom = table.Column<string>(maxLength: 20, nullable: false),
                    Prenom = table.Column<string>(maxLength: 20, nullable: false),
                    Genre = table.Column<int>(nullable: false),
                    DateNaissance = table.Column<DateTime>(nullable: false),
                    Matricule = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professeurs", x => x.ProfesseurID);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    SectionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.SectionID);
                });

            migrationBuilder.CreateTable(
                name: "SousDivisions",
                columns: table => new
                {
                    SousDivisionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SousDivisions", x => x.SousDivisionID);
                });

            migrationBuilder.CreateTable(
                name: "Ecoles",
                columns: table => new
                {
                    EcoleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PrefetID = table.Column<int>(nullable: false),
                    nom = table.Column<string>(maxLength: 30, nullable: false),
                    SousDivision = table.Column<string>(nullable: false),
                    DateCreation = table.Column<DateTime>(nullable: false),
                    Adresse = table.Column<string>(maxLength: 55, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ecoles", x => x.EcoleID);
                    table.ForeignKey(
                        name: "FK_Ecoles_Prefets_PrefetID",
                        column: x => x.PrefetID,
                        principalTable: "Prefets",
                        principalColumn: "PrefetID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    ClasseID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EcoleID = table.Column<int>(nullable: false),
                    Niveau = table.Column<string>(maxLength: 1, nullable: false),
                    Option = table.Column<string>(nullable: false),
                    Section = table.Column<string>(nullable: false),
                    AnneeScolaire = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.ClasseID);
                    table.ForeignKey(
                        name: "FK_Classes_Ecoles_EcoleID",
                        column: x => x.EcoleID,
                        principalTable: "Ecoles",
                        principalColumn: "EcoleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cours",
                columns: table => new
                {
                    CoursID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Intituler = table.Column<string>(maxLength: 20, nullable: false),
                    Volume = table.Column<int>(maxLength: 20, nullable: false),
                    Categorie = table.Column<string>(nullable: false),
                    ClasseID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cours", x => x.CoursID);
                    table.ForeignKey(
                        name: "FK_Cours_Classes_ClasseID",
                        column: x => x.ClasseID,
                        principalTable: "Classes",
                        principalColumn: "ClasseID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Inscriptions",
                columns: table => new
                {
                    InscriptionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClasseID = table.Column<int>(nullable: false),
                    EleveID = table.Column<int>(nullable: false),
                    AnneeScolaire = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscriptions", x => x.InscriptionID);
                    table.ForeignKey(
                        name: "FK_Inscriptions_Classes_ClasseID",
                        column: x => x.ClasseID,
                        principalTable: "Classes",
                        principalColumn: "ClasseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inscriptions_Eleves_EleveID",
                        column: x => x.EleveID,
                        principalTable: "Eleves",
                        principalColumn: "EleveID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Epreuves",
                columns: table => new
                {
                    EpreuveID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CoursID = table.Column<int>(nullable: false),
                    EleveID = table.Column<int>(nullable: false),
                    BulletinID = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: true),
                    Periode = table.Column<int>(nullable: false),
                    DateEpreuve = table.Column<DateTime>(nullable: false),
                    Total = table.Column<int>(nullable: false),
                    point = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Epreuves", x => x.EpreuveID);
                    table.ForeignKey(
                        name: "FK_Epreuves_Bulletins_BulletinID",
                        column: x => x.BulletinID,
                        principalTable: "Bulletins",
                        principalColumn: "BulletinID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Epreuves_Cours_CoursID",
                        column: x => x.CoursID,
                        principalTable: "Cours",
                        principalColumn: "CoursID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Epreuves_Eleves_EleveID",
                        column: x => x.EleveID,
                        principalTable: "Eleves",
                        principalColumn: "EleveID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lecons",
                columns: table => new
                {
                    LeconID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProfesseurID = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 55, nullable: true),
                    Duree = table.Column<DateTime>(nullable: false),
                    DateLecon = table.Column<DateTime>(nullable: false),
                    CoursID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lecons", x => x.LeconID);
                    table.ForeignKey(
                        name: "FK_Lecons_Cours_CoursID",
                        column: x => x.CoursID,
                        principalTable: "Cours",
                        principalColumn: "CoursID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lecons_Professeurs_ProfesseurID",
                        column: x => x.ProfesseurID,
                        principalTable: "Professeurs",
                        principalColumn: "ProfesseurID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Journals",
                columns: table => new
                {
                    JournalID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Resume = table.Column<string>(maxLength: 55, nullable: false),
                    LeconID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Journals", x => x.JournalID);
                    table.ForeignKey(
                        name: "FK_Journals_Lecons_LeconID",
                        column: x => x.LeconID,
                        principalTable: "Lecons",
                        principalColumn: "LeconID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Echanges",
                columns: table => new
                {
                    EchangeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InspecteurID = table.Column<int>(nullable: false),
                    JournalID = table.Column<int>(nullable: false),
                    Cote = table.Column<double>(nullable: false),
                    Message = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Echanges", x => x.EchangeID);
                    table.ForeignKey(
                        name: "FK_Echanges_Inspecteurs_InspecteurID",
                        column: x => x.InspecteurID,
                        principalTable: "Inspecteurs",
                        principalColumn: "InspecteurID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Echanges_Journals_JournalID",
                        column: x => x.JournalID,
                        principalTable: "Journals",
                        principalColumn: "JournalID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ressources",
                columns: table => new
                {
                    RessourceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EchangeID = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 55, nullable: true),
                    PathRessource = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ressources", x => x.RessourceID);
                    table.ForeignKey(
                        name: "FK_Ressources_Echanges_EchangeID",
                        column: x => x.EchangeID,
                        principalTable: "Echanges",
                        principalColumn: "EchangeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Classes_EcoleID",
                table: "Classes",
                column: "EcoleID");

            migrationBuilder.CreateIndex(
                name: "IX_Cours_ClasseID",
                table: "Cours",
                column: "ClasseID");

            migrationBuilder.CreateIndex(
                name: "IX_Echanges_InspecteurID",
                table: "Echanges",
                column: "InspecteurID");

            migrationBuilder.CreateIndex(
                name: "IX_Echanges_JournalID",
                table: "Echanges",
                column: "JournalID");

            migrationBuilder.CreateIndex(
                name: "IX_Ecoles_PrefetID",
                table: "Ecoles",
                column: "PrefetID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Epreuves_BulletinID",
                table: "Epreuves",
                column: "BulletinID");

            migrationBuilder.CreateIndex(
                name: "IX_Epreuves_CoursID",
                table: "Epreuves",
                column: "CoursID");

            migrationBuilder.CreateIndex(
                name: "IX_Epreuves_EleveID",
                table: "Epreuves",
                column: "EleveID");

            migrationBuilder.CreateIndex(
                name: "IX_Inscriptions_ClasseID",
                table: "Inscriptions",
                column: "ClasseID");

            migrationBuilder.CreateIndex(
                name: "IX_Inscriptions_EleveID",
                table: "Inscriptions",
                column: "EleveID");

            migrationBuilder.CreateIndex(
                name: "IX_Journals_LeconID",
                table: "Journals",
                column: "LeconID");

            migrationBuilder.CreateIndex(
                name: "IX_Lecons_CoursID",
                table: "Lecons",
                column: "CoursID");

            migrationBuilder.CreateIndex(
                name: "IX_Lecons_ProfesseurID",
                table: "Lecons",
                column: "ProfesseurID");

            migrationBuilder.CreateIndex(
                name: "IX_Ressources_EchangeID",
                table: "Ressources",
                column: "EchangeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Epreuves");

            migrationBuilder.DropTable(
                name: "Inscriptions");

            migrationBuilder.DropTable(
                name: "Options");

            migrationBuilder.DropTable(
                name: "Ressources");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "SousDivisions");

            migrationBuilder.DropTable(
                name: "Bulletins");

            migrationBuilder.DropTable(
                name: "Eleves");

            migrationBuilder.DropTable(
                name: "Echanges");

            migrationBuilder.DropTable(
                name: "Inspecteurs");

            migrationBuilder.DropTable(
                name: "Journals");

            migrationBuilder.DropTable(
                name: "Lecons");

            migrationBuilder.DropTable(
                name: "Cours");

            migrationBuilder.DropTable(
                name: "Professeurs");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Ecoles");

            migrationBuilder.DropTable(
                name: "Prefets");
        }
    }
}
