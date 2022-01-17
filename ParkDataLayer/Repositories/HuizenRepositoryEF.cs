using Microsoft.EntityFrameworkCore;
using ParkBusinessLayer.Interfaces;
using ParkBusinessLayer.Model;
using ParkDataLayer.Exceptions;
using ParkDataLayer.Mappers;
using System;
using System.Linq;

namespace ParkDataLayer.Repositories
{
    public class HuizenRepositoryEF : IHuizenRepository
    {
        private ParkbeheerContext pbx;
        public HuizenRepositoryEF()
        {
            pbx = new ParkbeheerContext();
        }

        private void SaveAndClear()
        {
            pbx.SaveChanges();
            pbx.ChangeTracker.Clear();
        }


        public Huis GeefHuis(int id)
        {
            try
            {
                return HuisMap.MapToDomain(pbx.Huizen.Where(x => x.Id == id)
                    .Include(x => x.Park)
                    .AsNoTracking()
                    .FirstOrDefault());
            }
            catch (Exception ex)
            {
                throw new RepositoryException("GeefHuis", ex);
            }
        }

        public bool HeeftHuis(string straat, int nummer, Park park)
        {
            try
            {
                return pbx.Huizen.Any(h => h.Straat == straat && h.Nummer == nummer && h.Park == ParkMap.MapToEF(park));
            }
            catch (Exception ex)
            {
                throw new RepositoryException("HeeftHuis", ex);
            }
    }

    public bool HeeftHuis(int id)
        {
            try
            {
                return pbx.Huizen.Any(h => h.Id == id);
            }
            catch (Exception ex)
            {
                throw new RepositoryException("HeeftHuis", ex);
            }
        }

        public void UpdateHuis(Huis huis)
        {
            try
            {
                pbx.Huizen.Update(HuisMap.MapToEF(huis, pbx));
                SaveAndClear();
            }
            catch (Exception ex)
            {
                throw new RepositoryException("UpdateHuis", ex);
            }
        }

        public void VoegHuisToe(Huis h)
        {
            try
            {
                pbx.Huizen.Add(HuisMap.MapToEF(h,pbx));
                SaveAndClear();

            }
            catch(Exception ex)
            {
                throw new RepositoryException("VoegHuisToe", ex);
            }
        }
    }
}
