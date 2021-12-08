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
        //public Kunstenaar_DTO kunstenaar;
        private Gebruiker_DTO model = new();
        //public Klant_DTO klant { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] public HttpClient httpClient { get; set; }
        [Inject] public ISidepanelService Sidepanel { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            Console.WriteLine(GebruikerId + ":gebruikersid");
            Console.WriteLine(gebruiker.Email + " " + "is Geb");
            //Console.WriteLine((gebruiker is Kunstenaar_DTO) + "dees is kunst");

            //Gebruiker_DTO geb;
            //dees api call werkt nie blijkbaar => gwn API call fixen eeuy
            //geb = await httpClient.GetFromJsonAsync<Gebruiker_DTO>($"api/Gebruiker/{GebruikerId}");
            //gebruiker = kunstenaar;

            //model = new Gebruiker_DTO
            //{
            //    GebruikerId = geb.GebruikerId,
            //    Gebruikersnaam = geb.Gebruikersnaam,
            //    GeboorteDatum = geb.GeboorteDatum,
            //    Email = geb.Email,
            //    Fotopad = geb.Fotopad
            //};
            //geen api call nodig eig, gwn de gebruikerDTO als param gegeven
            await Task.Delay(100);
            model = new Gebruiker_DTO
            {
                GebruikerId = gebruiker.GebruikerId,
                Gebruikersnaam = gebruiker.Gebruikersnaam,
                GeboorteDatum = gebruiker.GeboorteDatum,
                Email = gebruiker.Email, //email nie want in auth0 veranderd niet
                Fotopad = gebruiker.Fotopad,
                Details=gebruiker.Details
            };

        }


        private async Task EditGebruikerAsync()
        {
            await httpClient.PutAsJsonAsync($"api/Gebruiker/{GebruikerId}", model);
            //na edit terug naar account page om geg te zien
            NavigationManager.NavigateTo("/account", forceLoad: true); //TODO: miss hier geen hard refresh, bij finetunen dit verbeteren
        }
    }
}
