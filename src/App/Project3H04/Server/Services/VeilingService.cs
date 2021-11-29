﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;
using Project3H04.Server.Data;
using Project3H04.Shared.DTO;
using Project3H04.Shared.Kunstenaars;
using Project3H04.Shared.Kunstwerken;
using Project3H04.Shared.Veilingen;

namespace Project3H04.Server.Services {
    public class VeilingService : IVeilingService {
        private readonly ApplicationDbcontext _dbContext;

        public VeilingService(ApplicationDbcontext dbContext) {
            _dbContext = dbContext;
        }

        public async Task<Veiling_DTO> GetVeilingById(int id) {
            var x = (Veiling)_dbContext.Veilingen.OfType<Veiling>().FirstOrDefault(v => v.Id == id);
            Veiling_DTO v = await Task.Run(() => new Veiling_DTO {
                StartDatum = x.StartDatum,
                EindDatum = x.EindDatum,
                MinPrijs = x.MinPrijs,
                Kunstwerk = new Kunstwerk_DTO.Detail {
                    Id = x.Kunstwerk.Id,
                    Naam = x.Kunstwerk.Naam,
                    Prijs = x.Kunstwerk.Prijs,
                    Materiaal = x.Kunstwerk.Materiaal,
                    Kunstenaar = new Kunstenaar_DTO {
                        Details = x.Kunstwerk.Kunstenaar.Details,
                        StatusActiefKunstenaar = x.Kunstwerk.Kunstenaar.StatusActiefKunstenaar,
                        //Kunstwerken =  *LOOP*
                        Abonnement = new Abonnement_DTO {
                            Id = x.Kunstwerk.Kunstenaar.Abonnenment.Id,
                            StartDatum = x.Kunstwerk.Kunstenaar.Abonnenment.StartDatum,
                            EindDatum = x.Kunstwerk.Kunstenaar.Abonnenment.EindDatum,
                            AbonnementType = new AbonnementType_DTO {
                                Naam = x.Kunstwerk.Kunstenaar.Abonnenment.AbonnementType.Naam,
                                Verlooptijd = x.Kunstwerk.Kunstenaar.Abonnenment.AbonnementType.Verlooptijd,
                                Prijs = x.Kunstwerk.Kunstenaar.Abonnenment.AbonnementType.Prijs
                            }
                        }
                    }
                },
                BodenOpVeiling = (ICollection<Bod_DTO>)x.BodenOpVeiling.Select(x => new Bod_DTO {
                    BodPrijs = x.BodPrijs,
                    Datum = x.Datum,
                    Klant = new Klant_DTO {
                        GebruikerId = x.Klant.GebruikerId,
                        Gebruikersnaam = x.Klant.Gebruikersnaam,
                        GeboorteDatum = x.Klant.Geboortedatum,
                        Email = x.Klant.Email,
                        DatumCreatie = x.Klant.DatumCreatie,
                        Fotopad = x.Klant.FotoPad,
                        //TODO: Klant map (NTH): Maarten?
                        //Bestellingen = (ICollection<Bestelling_DTO.Index>)x.Bestellingen.Select(x => new Bestelling_DTO.Index {
                        //    Datum = x.Datum,
                        //    Straat = x.Adres.Straat,
                        //    Postcode = x.Adres.Postcode,
                        //    Gemeente = x.Adres.Gemeente,
                        //    TotalePrijs = x.TotalePrijs,
                        //
                        //    WinkelmandKunstwerken = (ICollection<Kunstwerk_DTO.Detail>)x.WinkelmandKunstwerken.Select(x => new Kunstwerk_DTO.Index {
                        //        Naam = x.Naam,
                        //        Prijs = x.Prijs,
                        //        Materiaal = x.Materiaal
                        //    })
                        //})
                    }
                })
            });

            return v;
        }

        public async Task<bool> AddBodToVeiling(Bod_DTO bod, int veilingId) {
             var veiling = _dbContext.Veilingen.SingleOrDefault(v => v.Id == veilingId);
             if (veiling == null)
                 return false;

             var klant = new Klant(bod.Klant.Gebruikersnaam, bod.Klant.GeboorteDatum, bod.Klant.Email, bod.Klant.Fotopad);
             veiling.VoegBodToe(klant, bod.BodPrijs, bod.Datum);

            _dbContext.Veilingen.Update(veiling);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> AddBodToKunstwerk(Bod_DTO bod, int kunstwerkId) {
            var veiling = _dbContext.Veilingen.SingleOrDefault(v => v.Kunstwerk.Id == kunstwerkId);
            if (veiling == null)
                return false;

            return await AddBodToVeiling(bod, veiling.Id);
        }

        public async Task<bool> CreateVeiling(Veiling_DTO veiling) {
            var abonnementType = new AbonnementType(veiling.Kunstwerk.Kunstenaar.Abonnement.AbonnementType.Naam, veiling.Kunstwerk.Kunstenaar.Abonnement.AbonnementType.Verlooptijd, veiling.Kunstwerk.Kunstenaar.Abonnement.AbonnementType.Prijs);
            var abonnement = new Abonnement(veiling.Kunstwerk.Kunstenaar.Abonnement.StartDatum, abonnementType);
            var kunstenaar = new Kunstenaar(veiling.Kunstwerk.Kunstenaar.Gebruikersnaam, veiling.Kunstwerk.Kunstenaar.GeboorteDatum, veiling.Kunstwerk.Kunstenaar.Email, veiling.Kunstwerk.Kunstenaar.Details, abonnement, veiling.Kunstwerk.Kunstenaar.Fotopad);
            var fotos = (List<Foto>) veiling.Kunstwerk.Fotos.Select(x => new Foto {
                Id = x.Id,
                Naam = x.Naam,
                Locatie = x.Locatie
            });

            Kunstwerk kunstwerk = new Kunstwerk(veiling.Kunstwerk.Naam, veiling.Kunstwerk.Einddatum, veiling.Kunstwerk.Prijs,
                veiling.Kunstwerk.Beschrijving, veiling.Kunstwerk.Lengte, veiling.Kunstwerk.Breedte, veiling.Kunstwerk.Hoogte, veiling.Kunstwerk.Gewicht, fotos, veiling.Kunstwerk.IsVeilbaar,
                veiling.Kunstwerk.Materiaal, kunstenaar);

            if (!kunstwerk.IsVeilbaar)
                return false;

            var v = new Veiling(veiling.StartDatum, veiling.EindDatum, veiling.MinPrijs, kunstwerk);

            await _dbContext.Veilingen.AddAsync(v);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}