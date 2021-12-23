using Project3H04.Client.Extensions;
using Project3H04.Client.Shared;
using Project3H04.Shared.Kunstwerken;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Project3H04.Client.Services
{
    public class KunstwerkService
    {
        private readonly HttpClient httpClient;
        private readonly PublicClient publicClient; //Deze http PublicClient gebruiken voor Anonymous--> 
        private const string endpoint = "api/kunstwerk";

        public KunstwerkService(HttpClient httpClient, PublicClient publicClient)
        {
            this.httpClient = httpClient;
            this.publicClient = publicClient;
        }

        public async Task<KunstwerkResponse.Index> GetIndexAsync()
        {
            var response = await publicClient.Client.GetFromJsonAsync<KunstwerkResponse.Index>($"{endpoint}");
            return response;
        }

        public async Task<KunstwerkResponse.Index> GetIndexAsync(Kunstwerk_DTO.Filter request)
        {
            var queryParameters = request.GetQueryString();
            var response = await publicClient.Client.GetFromJsonAsync<KunstwerkResponse.Index>($"{endpoint}?{queryParameters}");
            return response;
        }

        public async Task<KunstwerkResponse.Edit> EditAsync(Kunstwerk_DTO.Edit model)
        {
            var response = await httpClient.PutAsJsonAsync($"{endpoint}", model);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<KunstwerkResponse.Edit>();
        }

        public async Task<KunstwerkResponse.Create> CreateAsync(Kunstwerk_DTO.Create model)
        {
            var response = await httpClient.PostAsJsonAsync($"{endpoint}", model);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<KunstwerkResponse.Create>();
        }

        public Task<int> GetAantalKunstAsync()
        {
            return publicClient.Client.GetFromJsonAsync<int>($"{endpoint}/aantalKunst");
        }

        public Task<List<string>> GetMaterialenAsync(int aantal)
        {
            return publicClient.Client.GetFromJsonAsync<List<string>>($"{endpoint}/materiaal/{aantal}");
        }
    }
}
