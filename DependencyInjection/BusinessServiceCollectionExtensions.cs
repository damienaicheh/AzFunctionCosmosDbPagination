using AzFunctionCosmosDbPagination.Repositories;
using AzFunctionCosmosDbPagination.Repositories.Interfaces;
using AzFunctionCosmosDbPagination.Services;
using AzFunctionCosmosDbPagination.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AzFunctionCosmosDbPagination.DependencyInjection
{
    public static class BusinessServiceCollectionExtensions
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddSingleton<IVegetableRepository, VegetableRepository>();

            services.AddSingleton<IVegetableService, VegetableService>();

            return services;
        }
    }
}