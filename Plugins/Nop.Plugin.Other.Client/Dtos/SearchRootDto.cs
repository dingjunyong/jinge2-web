using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Other.Client.Dtos
{
    public  class SearchResultRootDto
    {
        public SearchResultRootDto()
        {
            SearchResult = new SearchResultDto();
        }
        [JsonProperty("SearchResult")]
        public SearchResultDto SearchResult { get; set; }
    }

    [JsonObject(Title = "SearchResult")]
    public class SearchResultDto
    {
        [JsonProperty("NoResults")]
        public bool NoResults { get; set; }

        [JsonProperty("Q")]
        public string Q { get; set; }

        [JsonProperty("PagingFilteringContext")]
        public PageableDto PagingFilteringContext { get; set; }

        [JsonProperty("Products")]
        public IList<ProductSimpleDto> Products { get; set; }
    }

}
