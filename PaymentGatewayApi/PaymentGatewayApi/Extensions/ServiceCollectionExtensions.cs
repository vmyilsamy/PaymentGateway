using System;
using System.Net.Http;
using PaymentGatewayApi.Clients;
using PaymentGatewayApi.Components;
using PaymentGatewayApi.Interfaces;
using PaymentGatewayApi.Services;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PaymentGatewayApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureComponents(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddSingleton<IMemoryCache, MemoryCache>();

            serviceCollection.AddSingleton<IRepository, InMemoryRepository>();

            string baseUri = configuration.GetValue<string>("AcquiringBankClientSettings:BaseUrl");

            serviceCollection
                .AddHttpClient<HttpClient>("acquiringBankClient", client => { 
                    client.BaseAddress = new Uri(baseUri);
                })
                .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler { UseDefaultCredentials = true });

            serviceCollection.AddScoped<IAcquiringBankClient, MockAcquiringBankClient>();
            
            serviceCollection.AddScoped<IPaymentService, PaymentService>();
            serviceCollection.AddScoped<IPaymentHistoryService, PaymentHistoryService>();
        }
    }
}