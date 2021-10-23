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
        public List<Kunstwerk_DTO> Kunstwerken { get; set; } = new List<Kunstwerk_DTO>();

        public async Task<List<Kunstwerk_DTO>> GetKunstwerken()
        {
            Kunstwerken = await _httpClient.GetFromJsonAsync<List<Kunstwerk_DTO>>("api/Kunstwerk");
            return Kunstwerken;
        }
    }
}
