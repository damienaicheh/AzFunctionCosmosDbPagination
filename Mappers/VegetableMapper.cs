using AzFunctionCosmosDbPagination.Dto;
using AzFunctionCosmosDbPagination.Entities;

namespace AzFunctionCosmosDbPagination.Mappers
{
    public static class VegetableMapper
    {
        public static VegetableDto MapToDto(Vegetable vegetable)
        {
            return new VegetableDto
            {
                Id = vegetable.Id,
                Name = vegetable.Name
            };
        }

        public static Vegetable MapFromDto(VegetableDto vegetableDto)
        {
            return new Vegetable
            {
                Id = vegetableDto.Id,
                Name = vegetableDto.Name
            };
        }
    }
}