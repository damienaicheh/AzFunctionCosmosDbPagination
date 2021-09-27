using AzFunctionCosmosDbPagination.Configuration.Interfaces;
using Azure.Cosmos;
using Azure.Cosmos.Serialization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace AzFunctionCosmosDbPagination.DependencyInjection
{
    public static class DataServiceCollectionExtensions
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services)
        {

            services.TryAddSingleton(factory =>
            {
                var cosmoDbConfiguration = factory.GetRequiredService<ICosmosDbConfiguration>();
                var clientOptions = new CosmosClientOptions()
                {
                    SerializerOptions = new CosmosSerializationOptions()
                    {
                        IgnoreNullValues = true
                    }
                };

                return new CosmosClient(cosmoDbConfiguration.ConnectionString, clientOptions);
            });

            return services;
        }
    }
}