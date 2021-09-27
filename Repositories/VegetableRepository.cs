using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AzFunctionCosmosDbPagination.Configuration.Interfaces;
using AzFunctionCosmosDbPagination.Entities;
using AzFunctionCosmosDbPagination.Repositories.Interfaces;
using Azure.Cosmos;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AzFunctionCosmosDbPagination.Repositories
{
    public class VegetableRepository : IVegetableRepository
    {
        protected readonly ICosmosDbConfiguration _cosmosDbConfiguration;
        protected readonly CosmosClient _client;
        protected readonly ILogger<VegetableRepository> _logger;

        public VegetableRepository(ICosmosDbConfiguration cosmosDbConfiguration,
                                   CosmosClient client,
                                   ILogger<VegetableRepository> logger)
        {
            _cosmosDbConfiguration = cosmosDbConfiguration
        ?? throw new ArgumentNullException(nameof(cosmosDbConfiguration));

            _client = client
                    ?? throw new ArgumentNullException(nameof(client));

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<PagedListResponse<Vegetable>> GetPaginatedVegetablesAsync(int pageSize, string continuationToken)
        {
            try
            {
                var container = GetContainer();
                var query = new QueryDefinition("SELECT * FROM v");

                var queryResultSetIterator = container.GetItemQueryIterator<Vegetable>(query, requestOptions: new QueryRequestOptions()
                {
                    MaxItemCount = pageSize,
                }, continuationToken: continuationToken).AsPages();
                var result = await queryResultSetIterator.FirstOrDefaultAsync();

                var sourceContinuationToken = result.ContinuationToken != null ? JsonConvert.DeserializeObject<ContinuationToken>(result.ContinuationToken).SourceContinuationToken : null;

                return new PagedListResponse<Vegetable>()
                {
                    ContinuationToken = sourceContinuationToken,
                    Data = result.Values.ToList(),
                };
            }
            catch (CosmosException ex)
            {
                _logger.LogError($"Entities was not retrieved successfully - error details: {ex.Message}");

                if (ex.Status != (int)HttpStatusCode.NotFound)
                {
                    throw;
                }

                return null;
            }
        }

        protected CosmosContainer GetContainer()
        {
            var database = _client.GetDatabase(_cosmosDbConfiguration.DatabaseName);
            var container = database.GetContainer(_cosmosDbConfiguration.VegetableContainerName);
            return container;
        }
    }
}