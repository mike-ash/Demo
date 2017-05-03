using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Semi_Webshop.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [NotMapped]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public double Price { get; set; }

        [Required]
        public string Description { get; set; }

        [NotMapped]
        public string Image { get; set; }


        public DateTime? ReleaseDate { get; set; }

    }
}