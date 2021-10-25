using Project3H04.Shared.Kunstenaars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Project3H04.Client.Services
{
    public class KunstenaarService : IKunstenaarService
    {
        private readonly HttpClient _httpClient;
        public KunstenaarService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public List<Kunstenaar_DTO> Kunstenaars { get; set; } = new List<Kunstenaar_DTO>();

        public async Task<List<Kunstenaar_DTO>> GetKunstenaars()
        {
            Kunstenaars = await _httpClient.GetFromJsonAsync<List<Kunstenaar_DTO>>("api/Kunstenaar");
            return Kunstenaars;
        }
    }
}
