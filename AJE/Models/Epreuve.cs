using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AJE.Models
{
    public enum Periode
    {
        Première_Période, Deuxième_Période, Premier_Semestre, Troisième_Période, Quatrième_Période, Deuxième_Semestre, Repéchage
    }

    [Table("Epreuves")]
    public class Epreuve
    {
        [Column("EpreuveID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EpreuveID { get; set; }
        public int CoursID { get; set; }
        public int EleveID { get; set; }

        [Display(Name = "Description")]
        [StringLength(50, ErrorMessage = "La description doit être plus petit que 50 charactères")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Le nom est obligatoire")]
        [EnumDataType(typeof(Periode))]
        public Periode? Periode { get; set; }

        [Display(Name = "Date d'épreuve")]
        [Required(ErrorMessage = "La date d'épreuve est obligatoire")]
        [DataType(DataType.Date)]
        public DateTime DateEpreuve { get; set; }

        [Display(Name = "Total")]
        [Required(ErrorMessage = "Le total est obligatoire")]
        public int Total { get; set; }

        [Display(Name = "Point")]
        [Required(ErrorMessage = "Le point est obligatoire")]
        public double Point { get; set; }

        public Cours Cours { get; set; }
        public Eleve Eleve { get; set; }
    }
}
