using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Project3H04.Shared.Kunstwerken;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Project3H04.Client.Shared;

namespace Project3H04.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            //AUTH
            builder.Services.AddOidcAuthentication(options =>
            {
                builder.Configuration.Bind("Auth0", options.ProviderOptions);
                options.ProviderOptions.ResponseType = "code";
            });
            //AUTH client
            builder.Services.AddHttpClient("ServerAPI",
            client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
            .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

            //UnAUTH client voor paginas anonymous te zetten
            //builder.Services.AddHttpClient("BlazorApp.PublicServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
            builder.Services.AddHttpClient<PublicClient>(client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
           

            //builder.Services.AddScoped<OrdersServ>();
            builder.Services.AddSingleton<CartState>();

            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>()
              .CreateClient("ServerAPI"));
            await builder.Build().RunAsync();
        }
    }
}
