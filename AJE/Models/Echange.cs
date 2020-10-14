using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AJE.Models
{
    [Table("Echanges")]
    public class Echange
    {
        [Column("EchangeID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EchangeID { get; set; }
        public int InspecteurID { get; set; }
        public int JournalID { get; set; }

        [Display(Name = "Cote")]
        [Required(ErrorMessage = "La cote est obligatoire")]
        public double Cote { get; set; }

        [Display(Name = "Message")]
        [Required(ErrorMessage = "Le nom est obligatoire")]
        [StringLength(250, ErrorMessage = "Le nom doit être plus petit que 250 charactères")]
        public string Message { get; set; }

        public Inspecteur Inspecteur { get; set; }
        public Journal Journal { get; set; }
        public ICollection<Ressource> Ressources { get; set; }
    }
}
