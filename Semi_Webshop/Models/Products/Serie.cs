using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Semi_Webshop.Models
{
    public class Serie
    {
        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("description")]
        public string Description { get; set; }

        [XmlElement("image")]
        public string Image { get; set; }

        [XmlElement("price")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public double Price { get; set; }
    }
}