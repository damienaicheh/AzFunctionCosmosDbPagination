namespace AzFunctionCosmosDbPagination.Dto
{
    public class PaginationFilterDto
    {
        public string ContinuationToken { get; set; }

        public int PageSize { get; set; }

        public PaginationFilterDto()
        {
            this.PageSize = 5;
        }

        public PaginationFilterDto(string continuationToken, int pageSize)
        {
            this.ContinuationToken = continuationToken;
            this.PageSize = pageSize > 0 ? pageSize : 20;
        }
    }
}