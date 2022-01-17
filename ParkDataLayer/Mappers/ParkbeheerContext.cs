using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ParkDataLayer.Model;

namespace ParkDataLayer.Mappers
{
    public class ParkbeheerContext : DbContext
    {
        public DbSet<ParkEF> Parken { get; set; }
        public DbSet<HuisEF> Huizen { get; set; }
        public DbSet<HuurcontractEF> Huurcontracten { get; set; }
        public DbSet<HuurderEF> Huurders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-R7T8D5F\SQLEXPRESS;Initial Catalog=Parkbeheer;Integrated Security=True");
        }
    }
}
