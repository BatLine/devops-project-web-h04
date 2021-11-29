﻿using Domain;
using Microsoft.EntityFrameworkCore;
using Project3H04.Server.Data;
using Project3H04.Shared.DTO;
using Project3H04.Shared.Klant;
using Project3H04.Shared.Kunstwerken;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project3H04.Server.Services {
    public class KlantService : IKlantService {
        private readonly ApplicationDbcontext DbContext;

        public KlantService(ApplicationDbcontext dbContext) {
            DbContext = dbContext;
        }

        public async Task<Klant_DTO> GetKlantByEmail(string email)
        {
            var x = DbContext.Gebruikers.OfType<Klant>().FirstOrDefault(k => k.Email == email);
            Klant_DTO k = await Task.Run(() => new Klant_DTO
            {
                Gebruikersnaam = x.Gebruikersnaam,
                GebruikerId = x.GebruikerId,
                GeboorteDatum = x.Geboortedatum,
                Email = x.Email,
                Fotopad = x.FotoPad
                //TODO: Klant map (NTH): Maarten?
                //Bestellingen = (ICollection<Bestelling_DTO.Index>)x.Bestellingen.Select(x => new Bestelling_DTO.Index
                //{
                //    Datum = x.Datum,
                //    Straat = x.Adres.Straat,
                //    Postcode = x.Adres.Postcode,
                //    Gemeente = x.Adres.Gemeente,
                //    TotalePrijs = x.TotalePrijs,

                //    WinkelmandKunstwerken = (ICollection<Kunstwerk_DTO.Detail>)x.WinkelmandKunstwerken.Select(x => new Kunstwerk_DTO.Index
                //    {
                //        Naam = x.Naam,
                //        Prijs = x.Prijs,
                //        Materiaal = x.Materiaal
                //    })
                //})
            });

            return k;
        }

        public async Task<Klant_DTO> GetKlantById(int id)
        {
            var x = (Klant)DbContext.Gebruikers.OfType<Klant>()/*NTH.Include(k => k.Boden).Include(k => k.Bestellingen).ThenInclude(x => x.WinkelmandKunstwerken)*/.SingleOrDefault(x => x.GebruikerId == id);
            //include van fotos ...
            Klant_DTO k = await Task.Run(() => new Klant_DTO {
                Gebruikersnaam = x.Gebruikersnaam,
                GebruikerId = x.GebruikerId,
                GeboorteDatum = x.Geboortedatum,
                Email = x.Email,
                Fotopad = x.FotoPad
                //TODO: Klant map (NTH): Maarten?
                //Bestellingen = (ICollection<Bestelling_DTO.Index>)x.Bestellingen.Select(x => new Bestelling_DTO.Index
                //{
                //    Datum = x.Datum,
                //    Straat = x.Adres.Straat,
                //    Postcode = x.Adres.Postcode,
                //    Gemeente = x.Adres.Gemeente,
                //    TotalePrijs = x.TotalePrijs,
                    
                //    WinkelmandKunstwerken = (ICollection<Kunstwerk_DTO.Detail>)x.WinkelmandKunstwerken.Select(x => new Kunstwerk_DTO.Index
                //    {
                //        Naam = x.Naam,
                //        Prijs = x.Prijs,
                //        Materiaal = x.Materiaal
                //    })
                //})
            });

            return k;
        }

        //public async Task<Klant_DTO> GetKlantById(int id)
        //{
        //    //var x = DbContext.Gebruikers.OfType<Klant>().FirstOrDefault(k => k.GebruikerId == id);
        //    //Klant_DTO k = await Task.Run(() => new Klant_DTO
        //    //{
        //    //    Gebruikersnaam = x.Gebruikersnaam,
        //    //    GebruikerId = x.GebruikerId,
        //    //    Email = x.Email,
        //    //    Fotopad = x.FotoPad,
        //    //    Bestellingen = (ICollection<Bestelling_DTO.Index>)x.Bestellingen.Select(x=> new Bestelling_DTO.Index{ 
        //    //        Datum = x.Datum,
        //    //        Straat = x.Adres.Straat,
        //    //        Postcode = x.Adres.Postcode,
        //    //        Gemeente = x.Adres.Gemeente,
        //    //        TotalePrijs = x.TotalePrijs,
        //    //        WinkelmandKunstwerken = (ICollection<Kunstwerk_DTO.Detail>)x.WinkelmandKunstwerken.Select(x=> new Kunstwerk_DTO.Index { 
        //    //            Naam = x.Naam,
        //    //            Prijs = x.Prijs,
        //    //            Materiaal = x.Materiaal
        //    //        })
        //    //    })
        //    //});

        //    var x = (Klant)DbContext.Gebruikers.OfType<Klant>().Include(k => k.Bestellingen).ThenInclude(x => x.WinkelmandKunstwerken).Include(k => k.Boden).SingleOrDefault(x => x.GebruikerId == id);
        //    Klant_DTO k = await Task.Run(() => new Klant_DTO
        //    {
        //        Gebruikersnaam = x.Gebruikersnaam,
        //        GebruikerId = x.GebruikerId,
        //        Email = x.Email,
        //        Fotopad = x.FotoPad//,
        //        //Bestellingen = (ICollection<Bestelling_DTO.Index>)x.Bestellingen.Select(x => new Bestelling_DTO.Index
        //        //{
        //        //    Datum = x.Datum,
        //        //    Straat = x.Adres.Straat,
        //        //    Postcode = x.Adres.Postcode,
        //        //    Gemeente = x.Adres.Gemeente,
        //        //    TotalePrijs = x.TotalePrijs,
        //        //    WinkelmandKunstwerken = (ICollection<Kunstwerk_DTO.Detail>)x.WinkelmandKunstwerken.Select(x => new Kunstwerk_DTO.Index
        //        //    {
        //        //        Naam = x.Naam,
        //        //        Prijs = x.Prijs,
        //        //        Materiaal = x.Materiaal
        //        //    })
        //        //})
        //    });

        //    return k;
        //}
       

        public async Task<string> CreateAsync(Klant_DTO klant)
        {
            //email uniek
            if (!DbContext.Gebruikers.Any(x => x.Email == klant.Email))
            {
                await Task.Delay(100);
                Klant k = new Klant(klant.Gebruikersnaam, klant.GeboorteDatum, klant.Email, klant.Fotopad);
                DbContext.Gebruikers.Add(k);
                DbContext.SaveChanges();
                return "succes";
            }
            else
                return "fail";
        }

        public async Task EditAsync(int id, Klant_DTO klant)
        {
            await Task.Delay(100);
            Klant k = DbContext.Gebruikers.OfType<Klant>().FirstOrDefault(k => k.GebruikerId == id);
            k.Edit(klant.Gebruikersnaam, klant.GeboorteDatum, klant.Email, k.FotoPad);
            DbContext.Update(k);
            DbContext.SaveChanges();
        }
    }
}
