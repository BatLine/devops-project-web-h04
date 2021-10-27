using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Project3H04.Shared.Kunstwerken;

namespace Project3H04.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            //builder.Services.AddScoped<IKunstwerkService, KunstwerkService>();
            //builder.Services.AddScoped<IKunstenaarService, KunstenaarService>();

            await builder.Build().RunAsync();
        }
    }
}
