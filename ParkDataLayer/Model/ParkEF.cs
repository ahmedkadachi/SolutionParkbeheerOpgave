using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Model
{
    public class ParkEF
    {
        public ParkEF(string naam, string locatie)
        {
            Naam = naam;
            Locatie = locatie;
        }
        public ParkEF(string id, string naam, string locatie)
        {
            Id = id;
            Naam = naam;
            Locatie = locatie;
        }

        [Key]
        public string Id { get; set; }

        [Column(TypeName = "Varchar(250)")]
        [Required]
        public string Naam { get; set; }

        [Column(TypeName = "Varchar(500)")]
        public string Locatie { get; set; }

        public List<HuisEF> Huizen { get; set; }
    }
}
