namespace AzFunctionCosmosDbPagination.Configuration.Interfaces
{
    public interface ICosmosDbConfiguration
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string VegetableContainerName { get; set; }
    }
}