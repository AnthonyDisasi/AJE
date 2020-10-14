using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AJE.Models
{
    [Table("SousDivisions")]
    public class SousDivision
    {
        [Column("SousDivisionID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SousDivisionID { get; set; }

        [Display(Name = "Nom")]
        [Required(ErrorMessage = "Le nom est obligatoire")]
        [StringLength(20, ErrorMessage = "Le nom doit être plus petit que 20 charactères")]
        public string Nom { get; set; }
    }
}
