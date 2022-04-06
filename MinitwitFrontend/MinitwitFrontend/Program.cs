using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MinitwitFrontend.Services;
using MinitwitFrontend.Shared;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MinitwitFrontend
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            //builder.Services.AddScoped(sp => new HttpClient
            //{
            //    BaseAddress = new Uri("https://localhost:7257/")
            //    //BaseAddress = new Uri("http://68.183.67.47:8000/")
            //    //BaseAddress = new Uri("https://catfact.ninja/")
            //});
            builder.Services.AddHttpClient("authorizedClient", (s, c) =>
            {
                c.BaseAddress = new Uri("https://localhost:7257/");
            });
            builder.Services.AddSingleton<LoginState>();
            builder.Services.AddTransient<IMessageService, MessageService>();
            builder.Services.AddTransient<IUserService, UserService>();
            await builder.Build().RunAsync();
        }
    }
}
