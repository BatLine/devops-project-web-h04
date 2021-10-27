using Domain;
using Microsoft.EntityFrameworkCore;
using Project3H04.Server.Data;
using Project3H04.Shared.Kunstenaars;
using Project3H04.Shared.Kunstwerken;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project3H04.Server.Services
{
    public class KunstenaarService : IKunstenaarService
    {

        private readonly ApplicationDbcontext dbContext;


        public KunstenaarService(ApplicationDbcontext dbContext)
        {
            this.dbContext = dbContext;
        }

        //public List<Kunstenaar_DTO> Kunstenaars { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public async Task<Kunstenaar_DTO> GetDetailAsync(int id)
        {
            //List<Kunstenaar> kunst =  dbContext.Gebruikers.Where(x => x is Kunstenaar).ToList();
            return await dbContext.Gebruikers.Where(x => x is Kunstenaar).Select(x => new Kunstenaar_DTO
            {
                Gebruikersnaam = x.Gebruikersnaam,
                GebruikerId = x.GebruikerId
                //andere props nog
            }).SingleOrDefaultAsync(x => x.GebruikerId == id);

        }

        public async Task<List<Kunstenaar_DTO>> GetKunstenaars(/*string searchterm*/)
        {
            //.Where(x=>x.Naam.Contains(searchterm))
            return await dbContext.Gebruikers.Where(x => x is Kunstenaar)
            .Select(x => new Kunstenaar_DTO
            {
                Gebruikersnaam = x.Gebruikersnaam,
                GebruikerId = x.GebruikerId
            }).ToListAsync();


            // return items;
        }

        //    {
        //        private readonly HttpClient _httpClient;
        //        public KunstwerkService(HttpClient httpClient)
        //        {
        //            _httpClient = httpClient;
        //        }

        //        //public List<Kunstwerk_DTO.Detail> Kunstwerken { get; set; }

        //        public async Task<Kunstwerk_DTO.Detail> GetDetailAsync(int id)
        //        {
        //            Kunstwerk_DTO.Detail kunst = await _httpClient.GetFromJsonAsync<Kunstwerk_DTO.Detail>($"api/Kunstwerk/{id}");
        //            return kunst;
        //        }

        //        public async Task<List<Kunstwerk_DTO.Index>> GetKunstwerken(string searchterm)
        //        {
        //            var werken = await _httpClient.GetFromJsonAsync<List<Kunstwerk_DTO.Index>>($"api/Kunstwerk?term={searchterm}");
        //            return werken;
        //        }
        //    }

    }
}
