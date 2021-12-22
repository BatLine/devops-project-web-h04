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
        private const string endpoint = "api/kunstwerk";

        public KunstwerkService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public Task<List<string>> GetMaterialenAsync(int aantal)
        {
            return httpClient.GetFromJsonAsync<List<string>>($"{endpoint}/materiaal/{aantal}");
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
    }
}
