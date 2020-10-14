using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AJE.Models
{
    [Table("Journals")]
    public class Journal
    {
        [Column("JournalID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JournalID { get; set; }

        [Display(Name = "Resum")]
        [Required(ErrorMessage = "Le resum est obligatoire")]
        [StringLength(55, ErrorMessage = "Le resum doit être plus petit que 55 charactères")]
        public string Resume { get; set; }
    }
}
