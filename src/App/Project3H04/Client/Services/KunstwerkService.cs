using Project3H04.Shared.Kunstwerken;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Project3H04.Client.Services
{
    public class KunstwerkService : IKunstwerkService
    {
        private readonly HttpClient _httpClient;
        public KunstwerkService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public List<Kunstwerk_DTO.Detail> Kunstwerken { get; set; } = new List<Kunstwerk_DTO.Detail>();

        public async Task<Kunstwerk_DTO.Detail> GetDetailAsync(int id)
        {
            Kunstwerk_DTO.Detail kunst = await _httpClient.GetFromJsonAsync<Kunstwerk_DTO.Detail>($"api/Kunstwerk/{id}");
            return kunst;
        }

        public async Task<List<Kunstwerk_DTO.Index>> GetKunstwerken()
        {
            Kunstwerken = await _httpClient.GetFromJsonAsync<List<Kunstwerk_DTO.Detail>>("api/Kunstwerk");
            return Kunstwerken.Select(x=> new Kunstwerk_DTO.Index(x.Id, x.Naam, x.Prijs, x.Fotos, x.NaamKunstenaar)).ToList();
        }
    }
}
