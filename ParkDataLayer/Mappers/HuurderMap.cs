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
    public class HuurderMap
    {
        public static Huurder MapToDomain(HuurderEF huurder)
        {
            try
            {
                return new Huurder(huurder.Id, huurder.Naam, new Contactgegevens(huurder.Email,huurder.Telefoon,huurder.Adres));

            }
            catch (Exception ex)
            {
                throw new MapperException("HuurderMap - MapToDomain", ex);
            }
        }
        public static HuurderEF MapToEF(Huurder huurder)
        {
            try
            {
                return new HuurderEF(huurder.Id, huurder.Naam, huurder.Contactgegevens.Tel, huurder.Contactgegevens.Email, huurder.Contactgegevens.Adres);

            }
            catch (Exception ex)
            {
                throw new MapperException("HuurderMap - MapToEF", ex);
            }
        }
    }
}
