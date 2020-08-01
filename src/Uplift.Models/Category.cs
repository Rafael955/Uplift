using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Uplift.Models.ValueObjects;

namespace Uplift.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name="Nome da Categoria")]
        public Name Name { get; set; }

        [Required]
        [Display(Name = "Ordem de Exibição")]
        public int DisplayOrder { get; set; }
    }
}
