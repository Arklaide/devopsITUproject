using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MinitwitFrontend.Services;
using MinitwitFrontend.Shared;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MinitwitFrontend
{
    public class Program
    {
        readonly static Boolean DEBUG = false;
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
                if (DEBUG)
                {
                    c.BaseAddress = new Uri("http://localhost:8000");
                }
                else
                {
                    c.BaseAddress = new Uri("http://164.92.132.67:8000");
                }
            });
            builder.Services.AddSingleton<LoginState>();
            builder.Services.AddTransient<IMessageService, MessageService>();
            builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddTransient<IFollowService, FollowService>();
            await builder.Build().RunAsync();
        }
    }
}
