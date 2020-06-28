using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Uplift.Models
{
    public class Service
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nome do Serviço")]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        [Display(Name = "Descrição")]
        public string LongDesc { get; set; }

        [DataType(DataType.ImageUrl)]
        [Display(Name = "Imagem")]
        public string ImageUrl { get; set; }

        #region Entity Framework Mapping
        [Required]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        [Required]
        public int FrequencyId { get; set; }

        [ForeignKey("FrequencyId")]
        public Frequency Frequency { get; set; }
        #endregion
    }
}
