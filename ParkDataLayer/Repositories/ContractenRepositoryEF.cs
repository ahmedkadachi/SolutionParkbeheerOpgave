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
    public class ContractenRepositoryEF : IContractenRepository
    {
        private ParkbeheerContext pbx;
        public ContractenRepositoryEF()
        {
            pbx = new ParkbeheerContext();
        }

        private void SaveAndClear()
        {
            pbx.SaveChanges();
            pbx.ChangeTracker.Clear();
        }
        public void AnnuleerContract(Huurcontract contract)
        {
            try
            {
                pbx.Huurcontracten.Remove(ContractMap.MapToEF(contract,pbx));
            }
            catch (Exception ex)
            {
                throw new RepositoryException("AnnuleerContract", ex);
            }
        }

        public Huurcontract GeefContract(string id)
        {
            try
            {
                return ContractMap.MapToDomain(pbx.Huurcontracten.Where(x => x.Id == id)
                    .Include(x => x.Huis)
                    .Include(x => x.Huurder)
                    .Include(x => x.Huis.Park)
                    .AsNoTracking()
                    .FirstOrDefault());
            }
            catch (Exception ex)
            {
                throw new RepositoryException("GeefContract", ex);
            }
        }

        public List<Huurcontract> GeefContracten(DateTime dtBegin, DateTime? dtEinde)
        {
            try
            {
                if (dtEinde is null)
                {
                    return pbx.Huurcontracten.Where(h => h.StartDatum >= dtBegin)
                                            .Include(x => x.Huis)
                                            .Include(x => x.Huurder)
                                            .Include(x => x.Huis.Park)
                                            .Select(h => ContractMap.MapToDomain(h))
                                            .AsNoTracking()
                                            .ToList();
                }
                else
                {


                    return pbx.Huurcontracten.Where(h => h.StartDatum >= dtBegin && h.StartDatum <= dtEinde)
                        .Include(x => x.Huis)
                        .Include(x => x.Huurder)
                        .Include(x => x.Huis.Park)
                        .Select(h => ContractMap.MapToDomain(h))
                        .AsNoTracking()
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw new RepositoryException("GeefContracten", ex);
            }
        }

        public bool HeeftContract(DateTime startDatum, int huurderid, int huisid)
        {
            try
            {
                return pbx.Huurcontracten.Any(h => h.StartDatum == startDatum && h.Huurder.Id == huurderid && h.Huis.Id == huisid);
            }
            catch (Exception ex)
            {
                throw new RepositoryException("HeeftContract", ex);
            }
        }

        public bool HeeftContract(string id)
        {
            try
            {
                return pbx.Huurcontracten.Any(h => h.Id == id);
            }
            catch (Exception ex)
            {
                throw new RepositoryException("HeeftContract", ex);
            }
        }

        public void UpdateContract(Huurcontract contract)
        {
            try
            {
                pbx.Huurcontracten.Update(ContractMap.MapToEF(contract, pbx));
                SaveAndClear();
            }
            catch (Exception ex)
            {
                throw new RepositoryException("UpdateContract", ex);
            }
        }

        public void VoegContractToe(Huurcontract contract)
        {
            try
            {
                pbx.Huurcontracten.Add(ContractMap.MapToEF(contract, pbx));
                SaveAndClear();
            }
            catch (Exception ex)
            {
                throw new RepositoryException("VoegContractToe", ex);
            }
        }
    }
}
