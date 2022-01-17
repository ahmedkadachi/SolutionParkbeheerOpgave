using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkDataLayer.Model
{
    public class HuurderEF
    {
        public HuurderEF(string naam, string telefoon, string email, string adres)
        {
            Naam = naam;
            Telefoon = telefoon;
            Email = email;
            Adres = adres;
        }
        public HuurderEF(int id, string naam, string telefoon, string email, string adres)
        {
            Id = id;
            Naam = naam;
            Telefoon = telefoon;
            Email = email;
            Adres = adres;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "Varchar(100)")]
        [Required]
        public string Naam { get; set; }

        [Column(TypeName = "Varchar(100)")]
        public string Telefoon { get; set; }

        [Column(TypeName = "Varchar(100)")]
        public string Email { get; set; }

        [Column(TypeName = "Varchar(100)")]
        public string Adres { get; set; }
        List<HuurcontractEF> Huurcontract { get; set; }
    }
}
