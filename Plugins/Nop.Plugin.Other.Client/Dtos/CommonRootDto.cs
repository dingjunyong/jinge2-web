using Newtonsoft.Json;
using Nop.Plugin.Other.Client.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Other.Client.Dtos
{
    [JsonObject(Title = "Pageable")]
    public class PageableDto
    {
        [JsonProperty("FirstItem")]
        public int FirstItem { get; set; }

        [JsonProperty("HasNextPage")]
        public bool HasNextPage { get; set; }

        [JsonProperty("HasPreviousPage")]
        public bool HasPreviousPage { get; set; }

        [JsonProperty("LastItem")]
        public int LastItem { get; set; }

        [JsonProperty("PageIndex")]
        public int PageIndex { get; set; }

        [JsonProperty("PageNumber")]
        public int PageNumber { get; set; }

        [JsonProperty("PageSize")]
        public int PageSize { get; set; }

        [JsonProperty("TotalItems")]
        public int TotalItems { get; set; }

        [JsonProperty("TotalPages")]
        public int TotalPages { get; set; }
    }

    [JsonObject(Title = "picture")]
    [PictureValidation]
    public class PictureDto
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("Position")]
        public int Position { get; set; }

        [JsonProperty("Src")]
        public string Src { get; set; }

        [JsonProperty("Attachment")]
        public string Attachment { get; set; }

        [JsonIgnore]
        public byte[] Binary { get; set; }

        [JsonIgnore]
        public string MimeType { get; set; }
    }
}
