using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Uplift.Models
{
    public class Frequency
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Contagem de Frequencia")]
        public int FrequencyCount { get; set; }
    }
}
