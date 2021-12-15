using Domain;
using Project3H04.Server.Data;
using Project3H04.Shared.DTO;
using Project3H04.Shared.Gebruiker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project3H04.Server.Services
{
    public class GebruikerService : IGebruikerService
    {
        private readonly ApplicationDbcontext dbContext;
        public GebruikerService(ApplicationDbcontext dbContext)
        {
            this.dbContext = dbContext;
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

        public async Task EditAsync(int id, Gebruiker_DTO geb)
        {
            await Task.Delay(100);
            Gebruiker gebruiker = dbContext.Gebruikers.FirstOrDefault(g => g.GebruikerId == id);
            gebruiker.Edit(geb.Gebruikersnaam, geb.GeboorteDatum/*, geb.Email*/, geb.Fotopad, geb.Details);
            dbContext.Update(gebruiker);
            dbContext.SaveChanges();
        }

    }
}
