using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Semi_Webshop.Models
{
    public class Movie
    {
        public ApplicationUser User { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }

    }
}