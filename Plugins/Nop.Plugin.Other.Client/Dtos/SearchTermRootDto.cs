using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Other.Client.Dtos
{

    public class SearchTermRootDto
    {
        public SearchTermRootDto()
        {
            SearchTerms = new List<SearchTermDto>();
        }

        [JsonProperty("SearchTerms")]
        public IList<SearchTermDto> SearchTerms { get; set; }
    }

    [JsonObject(Title = "SearchTerm")]
    public class SearchTermDto
    {
        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("Keyword")]
        public string Keyword { get; set; }

        [JsonProperty("StoreId")]
        public int StoreId { get; set; }

        [JsonProperty("Count")]
        public int Count { get; set; }
    }
}
