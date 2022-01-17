using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkBusinessLayer.Model;
using ParkDataLayer.Exceptions;
using ParkDataLayer.Model;

namespace ParkDataLayer.Mappers
{
    public class ParkMap
    {
        public static Park MapToDomain(ParkEF park)
        {
            return new Park(park.Id, park.Naam, park.Locatie);
        }
        public static ParkEF MapToEF(Park p)
        {
            try
            {
                return new ParkEF(p.Id, p.Naam, p.Locatie);

            }catch(Exception ex)
            {
                throw new MapperException("ParkMap - MapToEF", ex);
            }
        }
    }
}
