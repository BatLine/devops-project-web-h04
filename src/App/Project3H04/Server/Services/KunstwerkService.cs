using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; //=>>>>>>>>altijd deze usen !!!
using Project3H04.Server.Data;
using Project3H04.Shared;
using Project3H04.Shared.DTO;
using Project3H04.Shared.Kunstenaars;
using Project3H04.Shared.Kunstwerken;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project3H04.Server.Services
{
    public class KunstwerkService : IKunstwerkService
    {
        private readonly ApplicationDbcontext dbContext;

        public List<Kunstwerk_DTO.Detail> Kunstwerken { get; set; }

        public KunstwerkService(ApplicationDbcontext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Kunstwerk_DTO.Detail> GetDetailAsync(int id)
        {

            return await dbContext.Kunstwerken.Include(k => k.Fotos).Select(x => new Kunstwerk_DTO.Detail
            {
                Id = x.Id,
                Naam = x.Naam,
                Fotos = (List<Foto_DTO>)x.Fotos.Select(x => new Foto_DTO { Id = x.Id, Naam = x.Naam, Locatie = x.Locatie }),
                Kunstenaar = new Kunstenaar_DTO
                {
                    Gebruikersnaam = x.Kunstenaar.Gebruikersnaam,
                    GebruikerId = x.Kunstenaar.GebruikerId,
                },
                Prijs = x.Prijs,
                Beschrijving = x.Beschrijving,
                Materiaal = x.Materiaal,
                TeKoop = x.TeKoop

            }).SingleOrDefaultAsync(x => x.Id == id);

        }

        //.EntityFrameworkCore; //=>>>>>>>>altijd deze usen !!!
        public async Task<List<Kunstwerk_DTO.Index>> GetKunstwerken(Kunstwerk_DTO.Filter request)
        {

            List<Kunstwerk_DTO.Index> kunstwerken =
            await dbContext.Kunstwerken.Where(x => request.Materiaal == null || request.Materiaal.Contains(x.Materiaal))
           .Select(x => new Kunstwerk_DTO.Index()
           {
               Id = x.Id,
               Naam = x.Naam,
               HoofdFoto = new(x.Fotos.FirstOrDefault().Naam, x.Fotos.FirstOrDefault().Locatie), //enkel eerste foto is nodig voor index
               Materiaal = x.Materiaal,
               Kunstenaar = new Kunstenaar_DTO
               {
                   Gebruikersnaam = x.Kunstenaar.Gebruikersnaam,
                   GebruikerId = x.Kunstenaar.GebruikerId,
               },
               Prijs = x.Prijs
           }).Where(x => String.IsNullOrEmpty(request.Naam) || x.Naam.Contains(request.Naam))
           .Where(x => String.IsNullOrEmpty(request.Kunstenaar) || x.Kunstenaar.Gebruikersnaam.Contains(request.Kunstenaar))
           .Where(x => request.MinimumPrijs.Equals(default(decimal)) || x.Prijs >= request.MinimumPrijs)
           .Where(x => request.MaximumPrijs.Equals(default(decimal)) || x.Prijs <= request.MaximumPrijs)
           .Take(15).ToListAsync();

            return kunstwerken;
        }

        public async Task<int> CreateAsync(Kunstwerk_DTO.Create kunstwerk, int gebruikerId)
        {
            List<Foto> fotos = kunstwerk.Fotos.Select(fotoDTO => new Foto() { Naam = fotoDTO.Pad }).ToList();
            Kunstenaar kunstenaar = (Kunstenaar)dbContext.Gebruikers.Where(x => x is Kunstenaar).SingleOrDefault(g => g.GebruikerId == gebruikerId);

            Kunstwerk kunstwerkToCreate = new Kunstwerk(kunstwerk.Naam, DateTime.Now.AddDays(25), kunstwerk.Prijs, kunstwerk.Beschrijving, fotos, kunstwerk.IsVeilbaar, kunstwerk.Materiaal, kunstenaar);

            await dbContext.Kunstwerken.AddAsync(kunstwerkToCreate);
            await dbContext.SaveChangesAsync();

            return kunstwerkToCreate.Id;
        }

        public async Task UpdateAsync(Kunstwerk_DTO.Edit kunstwerk, int gebruikerId)
        {
            await Task.Delay(10);
            if (kunstwerk.KunstenaarId != gebruikerId)
            {
                throw new ArgumentException();
            }

            List<Foto> updatedFotoLijst = kunstwerk.Fotos.Select(fotoDTO => new Foto() { Id = fotoDTO.Id, Naam = fotoDTO.Pad }).ToList(); //id wordt meegegeven als de foto al in de databank zit
            Kunstenaar kunstenaar = (Kunstenaar)dbContext.Gebruikers.Where(x => x is Kunstenaar).SingleOrDefault(g => g.GebruikerId == gebruikerId);

            Kunstwerk kunstwerkToUpdate = dbContext.Kunstwerken.Include(k => k.Fotos).FirstOrDefault(x => x.Id == kunstwerk.Id);
            kunstwerkToUpdate.Edit(kunstwerk.Naam, DateTime.Now.AddDays(25), kunstwerk.Prijs, kunstwerk.Beschrijving, kunstwerk.IsVeilbaar, kunstwerk.Materiaal);

            //nodige fotos verwijderen
            List<Foto> teVerwijderen = kunstwerkToUpdate.Fotos.Where(x => !updatedFotoLijst.Contains(x)).ToList(); //alle fotos in de databank die niet in de updatedFotlijst staan moeten verwijderd worden
            if (teVerwijderen.Count() > 0)
            {
                dbContext.Fotos.RemoveRange(teVerwijderen);
            }

            //final foto update
            kunstwerkToUpdate.Fotos = updatedFotoLijst;


            dbContext.Kunstwerken.Update(kunstwerkToUpdate);
            dbContext.SaveChanges();
        }

        public async Task<List<string>> GetMediums(int amount) //aantal meestvoorkomende mediums ophalen
        {
            var kunstwerken = await dbContext.Kunstwerken
                .ToListAsync();
            return kunstwerken.OrderByDescending(g => g.Materiaal.Count())
                .Select(g => g.Materiaal)
                .Distinct()
                .Take(amount)
                .ToList();
        }
    }
}
