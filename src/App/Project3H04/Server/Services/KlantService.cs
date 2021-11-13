using Domain;
using Project3H04.Server.Data;
using Project3H04.Shared.DTO;
using Project3H04.Shared.Klant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project3H04.Server.Services
{
    public class KlantService : IKlantService
    {

        private readonly ApplicationDbcontext DbContext;
        public KlantService(ApplicationDbcontext dbContext)
        {
            DbContext = dbContext;
        }
        public async Task<Klant_DTO> GetKlantById(int id)
        {
            var x = DbContext.Gebruikers.OfType<Klant>().FirstOrDefault(k => k.GebruikerId == id);
            Klant_DTO k = await Task.Run(() => new Klant_DTO
            {
                Gebruikersnaam = x.Gebruikersnaam,
                GebruikerId = x.GebruikerId,
                Email = x.Email,
                Fotopad = x.FotoPad
            });
            return k;
        }
    }
}
