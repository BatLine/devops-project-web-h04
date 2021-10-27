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
            
            return await dbContext.Kunstwerken.Include(k => k.Fotos).Select(x=> new Kunstwerk_DTO.Detail {
                 Id = x.Id,
                 Naam = x.Naam,
                 Fotos = (List<Foto_DTO>)x.Fotos.Select(x => new Foto_DTO { Pad = x.Pad }),
                 Kunstenaar = new Kunstenaar_DTO
                 {
                     Gebruikersnaam = x.Kunstenaar.Gebruikersnaam,
                     GebruikerId = x.Kunstenaar.GebruikerId,
                 },
                 Prijs = x.Prijs, 
                 Beschrijving = x.Beschrijving, 
                 Materiaal= x.Materiaal
             }).SingleOrDefaultAsync(x => x.Id== id);

        }

        //.EntityFrameworkCore; //=>>>>>>>>altijd deze usen !!!
        public async Task<List<Kunstwerk_DTO.Index>> GetKunstwerken(/*string searchterm*/)
        {
            //.Where(x=>x.Naam.Contains(searchterm))
            return await dbContext.Kunstwerken
            .Select(x => new Kunstwerk_DTO.Index
            {
                Id = x.Id,
                Naam = x.Naam,
                Fotos = (List<Foto_DTO>)x.Fotos.Select(x => new Foto_DTO { Pad = x.Pad }),
                Kunstenaar = new Kunstenaar_DTO
                {
                    Gebruikersnaam = x.Kunstenaar.Gebruikersnaam,
                    GebruikerId = x.Kunstenaar.GebruikerId, 
                },
                Prijs = x.Prijs
            }).ToListAsync();


            // return items;
        }

        
    }
}
