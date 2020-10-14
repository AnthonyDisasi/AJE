using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AJE.Models
{
    [Table("Ecoles")]
    public class Ecole
    {
        public int EcoleID { get; set; }
        public int PrefetID { get; set; }

        [Display(Name = "Nom")]
        [Required(ErrorMessage = "Le nom est obligatoire")]
        [StringLength(30, ErrorMessage = "Le nom doit être plus petit que 30 charactères")]
        public string Nom { get; set; }

        [Display(Name = "Sous-division")]
        [Required(ErrorMessage = "La sous-division est obligatoire")]
        public string SousDivision { get; set; }

        [Display(Name = "Date création")]
        [Required(ErrorMessage = "Date création est obligatoire")]
        [DataType(DataType.Date)]
        public DateTime DateCreation { get; set; }

        [Display(Name = "Adresse")]
        [Required(ErrorMessage = "L'adresse est obligatoire")]
        [StringLength(55, ErrorMessage = "L'adresse doit être plus petit que 55 charactères")]
        public string Adresse { get; set; }

        public Prefet Prefet { get; set; }
        public ICollection<Classe> Classes { get; set; }
    }
}
