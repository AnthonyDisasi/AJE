using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AJE.Models
{
    [Table("Bulletins")]
    public class Bulletin
    {
        [Column("BulletinID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BulletinID { get; set; }

        [Display(Name = "Année scolaire")]
        [Required(ErrorMessage = "Année scolaire est obligatoire")]
        [DataType(DataType.Date)]
        public DateTime AnneeScolaire { get; set; }

        [Display(Name = "Pourcentage")]
        public double Pourcentage { get; set; }

        [Display(Name = "Mention")]
        public string Mention { get; set; }

        [Display(Name = "Application")]
        public string Application { get; set; }

        public ICollection<Epreuve> Epreuves { get; set; }
    }
}
