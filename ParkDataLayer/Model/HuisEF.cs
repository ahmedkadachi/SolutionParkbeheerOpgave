using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkDataLayer.Model
{
    public class HuisEF
    {
        public HuisEF( string straat, int nummer, bool actief)
        {
            Straat = straat;
            Nummer = nummer;
            Actief = actief;
        }
        public HuisEF(int id, string straat, int nummer, bool actief, ParkEF park)
        {
            Id = id;
            Straat = straat;
            Nummer = nummer;
            Actief = actief;
            Park = park;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "Varchar(250)")]
        public string Straat { get; set; }

        [Required]
        public int Nummer { get; set; }

        [Required]
        public bool Actief { get; set; }

        public ParkEF Park { get; set; }

        public List<HuurcontractEF> Huurcontracts { get; set; }
    }
}
