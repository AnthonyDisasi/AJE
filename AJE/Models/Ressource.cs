using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AJE.Models
{
    [Table("Ressources")]
    public class Ressource
    {
        [Column("RessourceID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RessourceID { get; set; }
        public int EchangeID { get; set; }

        [Display(Name = "Description")]
        [StringLength(55, ErrorMessage = "La description doit être plus petit que 55 charactères")]
        public string Description { get; set; }

        [Display(Name = "Chemin du fichier")]
        public string PathRessource { get; set; }

        public Echange Echange { get; set; }
    }
}
