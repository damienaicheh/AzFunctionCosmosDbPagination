using System;
using System.Collections.Generic;

namespace AzFunctionCosmosDbPagination.Dto
{
    public class PagedListResponseDto<T>
    {
        public string ContinuationToken { get; set; }

        public List<T> Data { get; set; }

        public string UrlEncodedContinuationToken
        {
            get => Uri.EscapeDataString(this.ContinuationToken ?? string.Empty);
        }
    }
}