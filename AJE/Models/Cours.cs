using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AJE.Models
{
    [Table("Cours")]
    public class Cours
    {
        [Column("CoursID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CoursID { get; set; }

        public int ClasseID { get; set; }

        [Display(Name = "Intituler")]
        [Required(ErrorMessage = "L'intituler est obligatoire")]
        [StringLength(20, ErrorMessage = "L'intituler doit être plus petit que 20 charactères")]
        public string Intituler { get; set; }

        [Display(Name = "Volume")]
        [StringLength(20, ErrorMessage = "Le volume doit être plus petit que 20 charactères")]
        public string Volume { get; set; }

        [Display(Name = "Categorie")]
        [Required(ErrorMessage = "La categorie est obligatoire")]
        public string Categorie { get; set; }

        public Classe Classe { get; set; }
        public ICollection<Epreuve> Epreuves { get; set; }
        public ICollection<Lecon> Lecons { get; set; }
    }
}
