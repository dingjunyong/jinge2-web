using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Other.Client.Dtos
{
    public class CatalogSimpleRootDto
    {
        public CatalogSimpleRootDto()
        {
            Categories = new List<CategorySimpleDto>();
        }

        [JsonProperty("Categories")]
        public IList<CategorySimpleDto> Categories { get; set; }
    }

    [JsonObject(Title = "CategorySimple")]
    public class CategorySimpleDto
    {

        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("NumberOfProducts")]
        public int NumberOfProducts { get; set; }

        [JsonProperty("SubCategories")]
        public List<CategorySimpleDto> SubCategories { get; set; }
    }
}
