using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using AzFunctionCosmosDbPagination.Dto;
using AzFunctionCosmosDbPagination.Mappers;
using AzFunctionCosmosDbPagination.Repositories.Interfaces;
using AzFunctionCosmosDbPagination.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace AzFunctionCosmosDbPagination.Services
{
    public class VegetableService : IVegetableService
    {
        private readonly ILogger<VegetableService> _logger;
        private readonly IVegetableRepository _vegetableRepository;

        public VegetableService(ILogger<VegetableService> logger, IVegetableRepository vegetableRepository)
        {
            _logger = logger ?? throw new ArgumentException(nameof(logger));
            _vegetableRepository = vegetableRepository ?? throw new ArgumentException(nameof(vegetableRepository));
        }

        public async Task<PagedListResponseDto<VegetableDto>> GetPaginatedVegetablesAsync(PaginationFilterDto filter)
        {
            try
            {
                var pagedListResponse = await _vegetableRepository.GetPaginatedVegetablesAsync(filter.PageSize, filter.ContinuationToken);

                if (pagedListResponse.Data != null)
                {
                    return new PagedListResponseDto<VegetableDto>()
                    {
                        ContinuationToken = pagedListResponse.ContinuationToken,
                        Data = pagedListResponse.Data.Select((v) => VegetableMapper.MapToDto(v)).ToList(),
                    };
                }

                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error while retreiving all vegetables", ex);
                return null;
            }
        }
    }
}