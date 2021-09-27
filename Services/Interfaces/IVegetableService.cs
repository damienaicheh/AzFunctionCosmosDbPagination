using System.Threading.Tasks;
using AzFunctionCosmosDbPagination.Dto;

namespace AzFunctionCosmosDbPagination.Services.Interfaces
{
    public interface IVegetableService
    {
        Task<PagedListResponseDto<VegetableDto>> GetPaginatedVegetablesAsync(PaginationFilterDto filter);
    }
}