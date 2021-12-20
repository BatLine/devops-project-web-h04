using Domain;
using Project3H04.Server.Data;
using Project3H04.Shared.DTO;
using Project3H04.Shared.Fotos;
using Project3H04.Shared.Gebruiker;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Project3H04.Server.Services
{
    public class GebruikerService : IGebruikerService
    {
        private readonly ApplicationDbcontext dbContext;
        private readonly IStorageService storageService;

        public GebruikerService(ApplicationDbcontext dbContext, IStorageService storageService)
        {
            this.dbContext = dbContext;
            this.storageService = storageService;
        }

        public async Task<Gebruiker_DTO> GetDetailAsync(int id)
        {

            var x = dbContext.Gebruikers.SingleOrDefault(x => x.GebruikerId == id);
            Gebruiker_DTO g = await Task.Run(() => new Gebruiker_DTO
            {
                Gebruikersnaam = x.Gebruikersnaam,
                GebruikerId = x.GebruikerId,
                Details = x.Details,
                Email = x.Email,
                Fotopad = x.FotoPad,
                GeboorteDatum = x.Geboortedatum
            });

            return g;
        }

        public async Task<GebruikerResponse.Edit> EditAsync(GebruikerRequest.Edit request)
        {
            Gebruiker_DTO gebruiker_DTO = request.Model;
            GebruikerResponse.Edit response = new();
            Gebruiker gebruiker = dbContext.Gebruikers.FirstOrDefault(g => g.GebruikerId == gebruiker_DTO.GebruikerId);

            if(request.newImage)
            {
                var imageFilename = Path.Combine("Kunstenaars", ""+ gebruiker_DTO.GebruikerId, Guid.NewGuid().ToString() + request.newImageName);
                var imagePath = $"{storageService.StorageBaseUri}{imageFilename}";
                gebruiker_DTO.Fotopad = imagePath;
                response.Sas = storageService.CreateUploadUri(imageFilename);
            }

            gebruiker.Edit(gebruiker_DTO.Gebruikersnaam, gebruiker_DTO.GeboorteDatum/*, gebruiker_DTO.Email*/, gebruiker_DTO.Fotopad, gebruiker_DTO.Details);
            dbContext.Update(gebruiker);
            await dbContext.SaveChangesAsync();
            return response;
        }

    }
}
