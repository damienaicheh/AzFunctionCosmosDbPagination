using System;
using System.Collections.Generic;

namespace AzFunctionCosmosDbPagination.Entities
{
    public class PagedListResponse<T>
    {
        public string ContinuationToken { get; set; }

        public List<T> Data { get; set; }
    }
}