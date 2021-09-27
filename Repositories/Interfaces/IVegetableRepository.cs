using System.Threading.Tasks;
using AzFunctionCosmosDbPagination.Entities;

namespace AzFunctionCosmosDbPagination.Repositories.Interfaces
{
    public interface IVegetableRepository
    {
        Task<PagedListResponse<Vegetable>> GetPaginatedVegetablesAsync(int pageSize, string continuationToken);
    }
}