using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkBusinessLayer.Model;
using ParkDataLayer.Exceptions;
using ParkDataLayer.Model;
using ParkDataLayer.Repositories;

namespace ParkDataLayer.Mappers
{
    public class HuisMap
    {
        public static Huis MapToDomain(HuisEF h)
        {
            return new Huis(h.Id, h.Straat, h.Nummer, h.Actief, ParkMap.MapToDomain(h.Park));
        }
        public static HuisEF MapToEF(Huis h, ParkbeheerContext pbx)
        {
            try
            {
                //kijken of de park bestaat
                ParkEF prkEF = pbx.Parken.Find(h.Park.Id);
                if (prkEF == null) prkEF = ParkMap.MapToEF(h.Park);

                //terug geven van mijn HuisEF variable
                return new HuisEF(h.Id, h.Straat, h.Nr, h.Actief, prkEF);

            }catch( Exception ex)
            {
                throw new MapperException("Huismap - MapToEF", ex);
            }
        }
    }
}
