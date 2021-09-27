using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using AzFunctionCosmosDbPagination.Dto;
using AzFunctionCosmosDbPagination.Services.Interfaces;

namespace Demo.CosmosPagination
{
    public class DemoAzCosmosPagination
    {
        private readonly ILogger<DemoAzCosmosPagination> _logger;
        private readonly IVegetableService _vegetableService;

        public DemoAzCosmosPagination(ILogger<DemoAzCosmosPagination> logger, IVegetableService vegetableService)
        {
            _logger = logger ?? throw new ArgumentException(nameof(logger));
            _vegetableService = vegetableService ?? throw new ArgumentException(nameof(vegetableService));
        }

        [FunctionName("demo-az-cosmos-pagination")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            try
            {
                string continuation = req.Query["continuation"];
                int pageSize;
                int.TryParse(req.Query["page_size"], out pageSize);

                var filter = new PaginationFilterDto(continuation, pageSize);

                var pageResults = await _vegetableService.GetPaginatedVegetablesAsync(filter);
                if (pageResults != null)
                {
                    return new OkObjectResult(pageResults);
                }

                return new NotFoundObjectResult("No vegetable found");
            }
            catch (Exception ex)
            {
                _logger.LogCritical("An unknown error occured: ", ex);
                return new StatusCodeResult(500);
            }

        }
    }
}
