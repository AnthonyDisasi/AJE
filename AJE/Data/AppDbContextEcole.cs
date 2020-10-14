using AJE.Models;
using Microsoft.EntityFrameworkCore;

namespace AJE.Data
{
    public class AppDbContextEcole : DbContext
    {
        public AppDbContextEcole(DbContextOptions<AppDbContextEcole> options) : base(options)
        {
        }
        public DbSet<Classe> Classes { get; set; }
        public DbSet<Bulletin> Bulletins { get; set; }
        public DbSet<Cours> Cours { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Ecole> Ecoles { get; set; }
        public DbSet<Echange> Echanges { get; set; }
        public DbSet<Eleve> Eleves { get; set; }
        public DbSet<Epreuve> Epreuves { get; set; }
        public DbSet<Inscription> Inscriptions { get; set; }
        public DbSet<Inspecteur> Inspecteurs { get; set; }
        public DbSet<Journal> Journals { get; set; }
        public DbSet<Lecon> Lecons { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Prefet> Prefets { get; set; }
        public DbSet<Professeur> Professeurs { get; set; }
        public DbSet<Ressource> Ressources { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<SousDivision> SousDivisions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
