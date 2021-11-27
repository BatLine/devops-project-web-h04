using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Append.Blazor.Sidepanel;
using Microsoft.AspNetCore.Components;
using Project3H04.Shared.DTO;
using Project3H04.Shared.Kunstenaars;

namespace Project3H04.Client.Components
{
    public partial class EditAccount
    {
        [Parameter] public int GebruikerId { get; set; }
        [Parameter] public Gebruiker_DTO gebruiker { get; set; }
        public Kunstenaar_DTO kunstenaar;
        private Kunstenaar_DTO model = new();
        //public Klant_DTO klant { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] public HttpClient httpClient { get; set; }
        [Inject] public ISidepanelService Sidepanel { get; set; }

        protected override async Task OnInitializedAsync()
        {
            //krijgen geb id via PARAMETER
            //kunstwerken ophalen
            Console.WriteLine(GebruikerId + ":gebruikersid");
            Console.WriteLine(gebruiker.Email + " " + "is kunstenaar");
            Console.WriteLine(gebruiker is Kunstenaar_DTO);
            if (gebruiker is Kunstenaar_DTO)
            {

                kunstenaar = await httpClient.GetFromJsonAsync<Kunstenaar_DTO>($"api/Kunstenaar/{GebruikerId}");
                gebruiker = kunstenaar;

                model = new Kunstenaar_DTO
                {
                    GebruikerId = kunstenaar.GebruikerId,
                    Gebruikersnaam = kunstenaar.Gebruikersnaam,
                    GeboorteDatum = kunstenaar.GeboorteDatum,
                    Email = kunstenaar.Email,
                    Fotopad = kunstenaar.Fotopad
                };
            }

            /*
            else
            {
                klant = await httpClient.GetFromJsonAsync<Klant_DTO>($"api/Klant/{GebruikerId}");
                gebruiker = klant;
            }*/

        }

        // Gebruiker_DTO geb;
        // Fetch the latest version of the product before editing.
        //hier de product met die id ophalen voor te editen !!!
        //var response = await IKunstwerkService.GetDetailAsync(new ProductRequest.GetDetail { ProductId = ProductId });
        // product = response.Product;
        //hier de product opvullen
        /*
        model = new ProductDto.Mutate
        {
            Category = product.CategoryName,
            Description = product.Description,
            InStock = product.IsInStock,
            Name = product.Name,
            Price = product.Price,
        };*/


        private async Task EditGebruikerAsync()
        {
            await httpClient.PutAsJsonAsync($"api/Kunstenaar/{model.GebruikerId}", model);
            //return await response.Content.ReadFromJsonAsync<>();
        }
    }
}
