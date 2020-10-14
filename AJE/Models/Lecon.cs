using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AJE.Models
{
    [Table("Lecons")]
    public class Lecon
    {
        [Column("LeconID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LeconID { get; set; }
        public int ProfesseurID { get; set; }

        [Display(Name = "Description")]
        [StringLength(55, ErrorMessage = "La description doit être plus petit que 55 charactères")]
        public string Description { get; set; }

        [Display(Name = "Durée")]
        [Required(ErrorMessage = "La durée est obligatoire")]
        [DataType(DataType.DateTime)]
        public DateTime Duree { get; set; }

        [Display(Name = "Date de la leçon")]
        [Required(ErrorMessage = "La date de la leçon est obligatoire")]
        [DataType(DataType.Date)]
        public DateTime DateLecon { get; set; }

        public Professeur Professeur { get; set; }
        public ICollection<Journal> Journals { get; set; }
    }
}
