using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AJE.Models
{
    [Table("Inscriptions")]
    public class Inscription
    {
        [Column("InscriptionID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InscriptionID { get; set; }
        public int ClasseID { get; set; }
        public int EleveID { get; set; }

        [Display(Name = "Année scolaire")]
        [Required(ErrorMessage = "Année scolaire est obligatoire")]
        [DataType(DataType.Date)]
        public DateTime AnneeScolaire { get; set; }

        public Classe Classe { get; set; }
        public Eleve Eleve { get; set; }
    }
}
