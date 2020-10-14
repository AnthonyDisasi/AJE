using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AJE.Models
{
    [Table("Categories")]
    public class Categorie
    {

        [Column("CategorieID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategorieID { get; set; }

        [Display(Name = "Nom")]
        [Required(ErrorMessage = "Le nom est obligatoire")]
        [StringLength(15, ErrorMessage = "Le nom doit être plus petit que 15 charactères")]
        public string Nom { get; set; }
    }
}
