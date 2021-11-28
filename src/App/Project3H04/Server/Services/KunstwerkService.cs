using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; //=>>>>>>>>altijd deze usen !!!
using Project3H04.Server.Data;
using Project3H04.Shared;
using Project3H04.Shared.DTO;
using Project3H04.Shared.Fotos;
using Project3H04.Shared.Kunstenaars;
using Project3H04.Shared.Kunstwerken;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Project3H04.Server.Services
{
    public class KunstwerkService : IKunstwerkService
    {
        private readonly ApplicationDbcontext dbContext;
        private readonly IStorageService storageService;

        public List<Kunstwerk_DTO.Detail> Kunstwerken { get; set; }

        public KunstwerkService(ApplicationDbcontext dbContext, IStorageService storageService)
        {
            this.dbContext = dbContext;
            this.storageService = storageService;
        }
        public async Task<Kunstwerk_DTO.Detail> GetDetailAsync(int id)
        {

            return await dbContext.Kunstwerken.Include(k => k.Fotos).Select(x => new Kunstwerk_DTO.Detail
            {
                Id = x.Id,
                Naam = x.Naam,
                Fotos = (List<Foto_DTO>)x.Fotos.Select(x => new Foto_DTO { Id = x.Id, Naam = x.Naam, Locatie = x.Locatie, Uploaded = true }),
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

        public async Task<KunstwerkResponse.Create> CreateAsync(Kunstwerk_DTO.Create kunstwerk, int gebruikerId)
        {
            //eerst nieuwe foto's regelen
            var uploadUris  = UploadFotos(kunstwerk.NieuweFotos);

            List<Foto> fotos = kunstwerk.NieuweFotos.Select(fotoDTO => new Foto(fotoDTO.Naam, fotoDTO.Locatie)).ToList();


            Kunstenaar kunstenaar = (Kunstenaar)dbContext.Gebruikers.Where(x => x is Kunstenaar).SingleOrDefault(g => g.GebruikerId == gebruikerId);

            Kunstwerk kunstwerkToCreate = new Kunstwerk(kunstwerk.Naam, DateTime.Now.AddDays(25), kunstwerk.Prijs, kunstwerk.Beschrijving, fotos, kunstwerk.IsVeilbaar, kunstwerk.Materiaal, kunstenaar);


            await dbContext.Kunstwerken.AddAsync(kunstwerkToCreate);
            await dbContext.SaveChangesAsync();

            return new()
            {
                KunstwerkId = kunstwerkToCreate.Id,
                UploadUris = uploadUris
            };
        }

        public async Task<KunstwerkResponse.Edit> UpdateAsync(Kunstwerk_DTO.Edit kunstwerk, int gebruikerId)
        {
            await Task.Delay(10);

            //eerst nieuwe foto's regelen
            var uploadUris = UploadFotos(kunstwerk.NieuweFotos);

            /*if (kunstwerk.KunstenaarId != gebruikerId)
            {
                throw new ArgumentException();
            }*/

            List<Foto> updatedFotoLijst = kunstwerk.Fotos.Select(fotoDTO => new Foto() { Id = fotoDTO.Id, Naam = fotoDTO.Naam, Locatie = fotoDTO.Locatie }).ToList(); //id wordt meegegeven als de foto al in de databank zit
            Kunstenaar kunstenaar = (Kunstenaar)dbContext.Gebruikers.Where(x => x is Kunstenaar).SingleOrDefault(g => g.GebruikerId == gebruikerId);

            Kunstwerk kunstwerkToUpdate = dbContext.Kunstwerken.Include(k => k.Fotos).FirstOrDefault(x => x.Id == kunstwerk.Id);
            kunstwerkToUpdate.Edit(kunstwerk.Naam, DateTime.Now.AddDays(25), kunstwerk.Prijs, kunstwerk.Beschrijving, kunstwerk.IsVeilbaar, kunstwerk.Materiaal);

            //final foto update
            kunstwerkToUpdate.Fotos = updatedFotoLijst;


            dbContext.Kunstwerken.Update(kunstwerkToUpdate);
            dbContext.SaveChanges();

            //nodige fotos verwijderen
            List<Foto> teVerwijderen = kunstwerkToUpdate.Fotos.Where(x => !updatedFotoLijst.Contains(x)).ToList(); //alle fotos in de databank die niet in de updatedFotlijst staan moeten verwijderd worden
            if (teVerwijderen.Count() > 0)
            {
                dbContext.Fotos.RemoveRange(teVerwijderen);
            }

            dbContext.SaveChanges();

            return new() { UploadUris = uploadUris };
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

        private IList<Uri> UploadFotos(IList<Foto_DTO> nieuweFotos)
        {
            IList<Uri> uploadUris = new List<Uri>();
            foreach (Foto_DTO foto in nieuweFotos)
            {
                var imageFilename = Path.Combine("Kunstwerken", Guid.NewGuid().ToString(), foto.Naam);
                uploadUris.Add(storageService.CreateUploadUri(imageFilename));

                foto.Locatie = storageService.StorageBaseUri; //opslaan in db
                foto.Naam = imageFilename;
            }


            return uploadUris;
        }
    }
}
