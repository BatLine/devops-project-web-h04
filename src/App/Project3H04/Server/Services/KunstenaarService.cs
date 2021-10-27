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

        //public List<Kunstenaar_DTO> Kunstenaars { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Task<List<Kunstenaar_DTO>> GetKunstenaars()
        {
            throw new NotImplementedException();
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
