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
                Fotos = (List<Foto_DTO>)x.Fotos.Select(x => new Foto_DTO { Id = x.Id, Pad = x.Pad }),
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
        public async Task<List<Kunstwerk_DTO.Index>> GetKunstwerken([FromQuery(Name = "termArtwork")] string termArtwork, [FromQuery(Name = "termArtist")] string termArtist, [FromQuery(Name = "termMinimumPrice")] decimal termMinimumPrice, [FromQuery(Name = "termMaximumPrice")] decimal termMaximumPrice, int take, [FromQuery(Name = "filters")] List<string> filters)
        {
            // check: typ KUNST => extra metaal
            //check : searchTerm in lokale variable, wordt deze bijgehouden??
            List<Kunstwerk_DTO.Index> kunstwerken =
            await dbContext.Kunstwerken.Where(x => filters.Count == 0 || filters.Contains(x.Materiaal))
           .Select(x => new Kunstwerk_DTO.Index
           {
               Id = x.Id,
               Naam = x.Naam,
               Fotos = (List<Foto_DTO>)x.Fotos.Select(x => new Foto_DTO { Pad = x.Pad }),
               Materiaal = x.Materiaal,
               Kunstenaar = new Kunstenaar_DTO
               {
                   Gebruikersnaam = x.Kunstenaar.Gebruikersnaam,
                   GebruikerId = x.Kunstenaar.GebruikerId,
               },
               Prijs = x.Prijs
           }).Where(x => String.IsNullOrEmpty(termArtwork) || x.Naam.Contains(termArtwork))
           .Where(x => String.IsNullOrEmpty(termArtist) || x.Kunstenaar.Gebruikersnaam.Contains(termArtist))
           .Where(x => termMinimumPrice.Equals(default(decimal)) || x.Prijs >= termMinimumPrice)
           .Where(x => termMaximumPrice.Equals(default(decimal)) || x.Prijs <= termMaximumPrice)
           .Take(take).ToListAsync();

            return kunstwerken;
        }

        public async Task<int> CreateAsync(Kunstwerk_DTO.Create kunstwerk, int gebruikerId)
        {
            List<Foto> fotos = kunstwerk.Fotos.Select(fotoDTO => new Foto { Pad = fotoDTO.Pad }).ToList();
            Kunstenaar kunstenaar = (Kunstenaar)dbContext.Gebruikers.Where(x => x is Kunstenaar).SingleOrDefault(g => g.GebruikerId == gebruikerId);

            Kunstwerk kunstwerkToCreate = new Kunstwerk(kunstwerk.Naam, DateTime.Now.AddDays(25), kunstwerk.Prijs, kunstwerk.Beschrijving, fotos, kunstwerk.IsVeilbaar, kunstwerk.Materiaal, kunstenaar);

            await dbContext.Kunstwerken.AddAsync(kunstwerkToCreate);
            await dbContext.SaveChangesAsync();

            return kunstwerkToCreate.Id;
        }

        public async Task UpdateAsync(Kunstwerk_DTO.Edit kunstwerk, int gebruikerId)
        {
            if(kunstwerk.KunstenaarId != gebruikerId)
            {
                throw new ArgumentException();
            }

            List<Foto> fotos = kunstwerk.Fotos.Select(fotoDTO => new Foto { Id = fotoDTO.Id, Pad = fotoDTO.Pad }).ToList(); //id wordt meegegeven als de foto al in de databank zit
            Kunstenaar kunstenaar = (Kunstenaar)dbContext.Gebruikers.Where(x => x is Kunstenaar).SingleOrDefault(g => g.GebruikerId == gebruikerId);

            Kunstwerk kunstwerkToUpdate = new Kunstwerk(kunstwerk.Naam, DateTime.Now.AddDays(25), kunstwerk.Prijs, kunstwerk.Beschrijving, fotos, kunstwerk.IsVeilbaar, kunstwerk.Materiaal, kunstenaar);
            kunstwerkToUpdate.Id = kunstwerk.Id;

            dbContext.Kunstwerken.Update(kunstwerkToUpdate);
            await dbContext.SaveChangesAsync();
        }
    }
}
