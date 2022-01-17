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
    public class ContractMap
    {
        public static Huurcontract MapToDomain(HuurcontractEF hc)
        {
            try
            {
                return new Huurcontract(hc.Id, new Huurperiode(hc.StartDatum, hc.AantalDagen), HuurderMap.MapToDomain(hc.Huurder), HuisMap.MapToDomain(hc.Huis));
            }
            catch (Exception ex)
            {
                throw new MapperException("ContractMap - MapToDomain", ex);
            }
        }
        public static HuurcontractEF MapToEF(Huurcontract hc, ParkbeheerContext pbx)
        {
            try
            {
                //checken ofdat huis en huurder bestaan of niet
                HuisEF huis = pbx.Huizen.Find(hc.Huis.Id);
                HuurderEF huurder = pbx.Huurders.Find(hc.Huurder.Id);

                if (huis == null) huis = HuisMap.MapToEF(hc.Huis, pbx);
                if (huurder == null) huurder = HuurderMap.MapToEF(hc.Huurder);

                return new HuurcontractEF(hc.Id, hc.Huurperiode.StartDatum, hc.Huurperiode.EindDatum, hc.Huurperiode.Aantaldagen, huis, huurder);
            }
            catch (Exception ex)
            {
                throw new MapperException("ContractMap - MapToEF", ex);
            }
           
        }
    }
}
