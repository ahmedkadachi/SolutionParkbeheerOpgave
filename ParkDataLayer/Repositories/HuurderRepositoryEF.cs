using Microsoft.EntityFrameworkCore;
using ParkBusinessLayer.Interfaces;
using ParkBusinessLayer.Model;
using ParkDataLayer.Exceptions;
using ParkDataLayer.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkDataLayer.Repositories
{
    public class HuurderRepositoryEF : IHuurderRepository
    {
        private ParkbeheerContext pbx;
        public HuurderRepositoryEF()
        {
            pbx = new ParkbeheerContext();
        }

        private void SaveAndClear()
        {
            pbx.SaveChanges();
            pbx.ChangeTracker.Clear();
        }
        public Huurder GeefHuurder(int id)
        {
            try
            {
                return HuurderMap.MapToDomain(pbx.Huurders.Where(x => x.Id == id)
                    .AsNoTracking()
                    .FirstOrDefault());
            }
            catch (Exception ex)
            {
                throw new RepositoryException("GeefHuurder", ex);
            }
        }

        public List<Huurder> GeefHuurders(string naam)
        {
            try
            {
                return pbx.Huurders.Where(h => h.Naam == naam)
                    .Select(h => HuurderMap.MapToDomain(h))
                    .AsNoTracking()
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new RepositoryException("GeefHuurders", ex);
            }
        }

        public bool HeeftHuurder(string naam, Contactgegevens contact)
        {
            try
            {
                return pbx.Huurders.Any(h => h.Naam == naam && h.Telefoon == contact.Tel && h.Adres == contact.Adres && h.Email == contact.Email);
            }
            catch (Exception ex)
            {
                throw new RepositoryException("HeeftHuurder", ex);
            }
        }

        public bool HeeftHuurder(int id)
        {
            try
            {
                return pbx.Huurders.Any(h => h.Id == id);
            }
            catch (Exception ex)
            {
                throw new RepositoryException("HeeftHuurder", ex);
            }
        }

        public void UpdateHuurder(Huurder huurder)
        {
            try
            {
                pbx.Huurders.Update(HuurderMap.MapToEF(huurder));
                SaveAndClear();
            }
            catch (Exception ex)
            {
                throw new RepositoryException("UpdateHuurder", ex);
            }
        }

        public void VoegHuurderToe(Huurder h)
        {
            try
            {
                pbx.Huurders.Add(HuurderMap.MapToEF(h));
                SaveAndClear();
            }
            catch (Exception ex)
            {
                throw new RepositoryException("VoegHuurderToe", ex);
            }
        }
    }
}
