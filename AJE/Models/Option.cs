﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AJE.Models
{
    [Table("Options")]
    public class Option
    {
        [Column("OptionID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OptionID { get; set; }

        [Display(Name = "Nom")]
        [Required(ErrorMessage = "Le nom est obligatoire")]
        [StringLength(20, ErrorMessage = "Le nom doit être plus petit que 20 charactères")]
        public string Nom { get; set; }
    }
}
