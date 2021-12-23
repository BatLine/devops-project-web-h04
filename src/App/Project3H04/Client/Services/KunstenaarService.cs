using Project3H04.Client.Shared;
using Project3H04.Shared.Kunstenaars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Project3H04.Client.Services
{
    public class KunstenaarService
    {
        private readonly HttpClient authorisedClient;
        private readonly PublicClient publicClient; //Deze http PublicClient gebruiken voor Anonymous--> 
        private const string endpoint = "api/kunstwerk";

        public KunstenaarService(HttpClient httpClient, PublicClient publicClient)
        {
            this.authorisedClient = httpClient;
            this.publicClient = publicClient;
        }

        public async Task<List<Kunstenaar_DTO>> GetRecentArtistsAsync() {
            var kunstenaars = await publicClient.Client.GetFromJsonAsync<List<Kunstenaar_DTO>>("api/Kunstenaar?take=4&recentArtists=true");
            return kunstenaars;
        }

        public async Task<List<Kunstenaar_DTO>> GetIndexAsync()
        {
            var kunstenaars = await publicClient.Client.GetFromJsonAsync<List<Kunstenaar_DTO>>("api/Kunstenaar");
            return kunstenaars;
        }

        public async Task<List<Kunstenaar_DTO>> GetIndexAsync(string searchTerm)
        {
            var kunstenaars = await publicClient.Client.GetFromJsonAsync<List<Kunstenaar_DTO>>($"api/Kunstenaar?term={searchTerm}");
            return kunstenaars;
        }

        public async Task<Kunstenaar_DTO> GetDetailAsync(int Id)
        {
            var kunstenaar = await publicClient.Client.GetFromJsonAsync<Kunstenaar_DTO>($"api/Kunstenaar/{Id}");
            return kunstenaar;
        }
    }
}
