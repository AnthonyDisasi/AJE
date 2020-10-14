using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AJE.Models
{
    [Table("Eleves")]
    public class Eleve
    {
        [Column("EleveID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EleveID { get; set; }

        [Display(Name = "Nom")]
        [Required(ErrorMessage = "Le nom est obligatoire")]
        [StringLength(20, ErrorMessage = "Le nom doit être plus petit que 20 charactères")]
        public string Nom { get; set; }

        [Display(Name = "Postnom")]
        [Required(ErrorMessage = "Le postnom est obligatoire")]
        [StringLength(20, ErrorMessage = "Le postnom doit être plus petit que 20 charactères")]
        public string Postnom { get; set; }

        [Display(Name = "Prenom")]
        [Required(ErrorMessage = "Le prenom est obligatoire")]
        [StringLength(20, ErrorMessage = "Le prenom doit être plus petit que 20 charactères")]
        public string Prenom { get; set; }

        [Required(ErrorMessage = "Le nom est obligatoire")]
        [EnumDataType(typeof(Genre))]
        public Genre? Genre { get; set; }

        [Display(Name = "Date de naissance")]
        [Required(ErrorMessage = "La date de naissance est obligatoire")]
        [DataType(DataType.Date)]
        public DateTime DateNaissance { get; set; }

        [Display(Name = "Matricule")]
        [Required(ErrorMessage = "Le matricule est obligatoire")]
        [StringLength(20, ErrorMessage = "Le matricule doit être plus petit que 20 charactères")]
        public string Matricule { get; set; }

        public ICollection<Inscription> Inscriptions { get; set; }
        public ICollection<Epreuve> Epreuves { get; set; }
    }
}
