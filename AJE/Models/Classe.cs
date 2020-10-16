using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AJE.Models
{
    [Table("Classes")]
    public class Classe
    {
        [Column("ClasseID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClasseID { get; set; }
        public int EcoleID { get; set; }

        [Display(Name = "Niveau")]
        [Required(ErrorMessage = "Le niveau est obligatoire")]
        [StringLength(1, ErrorMessage = "Le niveau doit être plus petit que 1 charactères")]
        public string Niveau { get; set; }

        [Display(Name = "Option")]
        [Required(ErrorMessage = "L'option est obligatoire")]
        public string Option { get; set; }

        [Display(Name = "Section")]
        [Required(ErrorMessage = "La section est obligatoire")]
        public string Section { get; set; }

        [Display(Name ="Nom de la classe")]
        public string Nomcomplet 
        {
            get
            {
                if(Niveau == "1")
                {
                    return Niveau + "ère " + Section + " " + Option;
                }
                else
                {
                    return Niveau + "ème " + Section + " " + Option;
                }
            }
        }

        public Ecole Ecole { get; set; }
        public ICollection<Inscription> Inscriptions { get; set; }
        public ICollection<Cours> Cours { get; set; }
    }
}
