# Paginate your results using Azure Cosmos DB

Sample source code for the following blog post :

##### English version :
[https://damienaicheh.github.io/azure/2021/09/28/azure-cosmosdb-pagination-en](https://damienaicheh.github.io/azure/2021/09/28/azure-cosmosdb-pagination-en)

##### French version :
[https://damienaicheh.github.io/azure/2021/09/28/azure-cosmosdb-pagination-fr](https://damienaicheh.github.io/azure/2021/09/28/azure-cosmosdb-pagination-fr)

To run this Azure Function project, you need to:
- Create an [Azure Cosmos DB][azure-cosmos-db-link] database and give it a name, for example: `cosmos-vegetables-001` 
- Add a Container called `vegetable` for instance
- Add items with this format:

```json
{
    "id": "cf8fc35d-adae-44ae-9a47-010d790de966",
    "name": "spinach"
}
```

Create a `local.settings.json` file with this format (Of course you can adapt the database name and container name as you like):

```json
{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet"
  },
  "CosmosDbSettings": {
    "ConnectionString": "YOUR_CONNECTION_STRING",
    "DatabaseName": "cosmos-vegetables-001",
    "VegetableContainerName": "vegetable"
  }
}
```


[azure-cosmos-db-link]: https://azure.microsoft.com/fr-fr/services/cosmos-db/
