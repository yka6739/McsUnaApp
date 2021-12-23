using Blazored.LocalStorage;
using McsUnaApp.Client.Contracts;
using McsUnaApp.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace McsUnaApp.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddBlazoredLocalStorage();
            builder.Services

               .AddScoped<IStudentService, StudentService>()
               
               ;

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });


            var apiUrl = new Uri(builder.Configuration["apiUrl"]);

            void RegisterTypeClient<TClient, TImplementation>(Uri apiBaseUrl)
                where TClient : class
                where TImplementation : class,
                TClient
            {
                builder.Services.AddHttpClient<TClient, TImplementation>(client =>
                {
                    client.BaseAddress = apiBaseUrl;

                });//.AddHttpMessageHandler<ValidateHeaderHandler>();


            }
            RegisterTypeClient<IHttpService, HttpService>(apiUrl);


           // builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();





            await builder.Build().RunAsync();
        }
    }
}
