using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkDataLayer.Model
{
    public class HuurcontractEF
    {
        public HuurcontractEF(DateTime startDatum, DateTime eindDatum, int aantalDagen)
        {
            StartDatum = startDatum;
            EindDatum = eindDatum;
            AantalDagen = aantalDagen;
        }
        public HuurcontractEF(string id, DateTime startDatum, DateTime eindDatum, int aantalDagen)
        {
            Id = id;
            StartDatum = startDatum;
            EindDatum = eindDatum;
            AantalDagen = aantalDagen;
        }
        public HuurcontractEF(string id, DateTime startDatum, DateTime eindDatum, int aantalDagen, HuisEF huis, HuurderEF huurder)
        {
            Id = id;
            StartDatum = startDatum;
            EindDatum = eindDatum;
            AantalDagen = aantalDagen;
            Huis = huis;
            Huurder = huurder;
        }

        [Key]
        [Column(TypeName = "Varchar(25)")]
        public string Id { get; set; }

        [Required]
        public DateTime StartDatum { get; set; }

        [Required]
        public DateTime EindDatum { get; set; }

        [Required]
        public int AantalDagen { get; set; }

        public HuisEF Huis { get; set; }
        public HuurderEF Huurder { get; set; }
    }
}
