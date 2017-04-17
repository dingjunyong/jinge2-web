using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Other.Client.Dtos
{
    public class MobileHomeRootDto
    {

        public MobileHomeRootDto()
        {
            Activitys = new List<ActivityDto>();
            CatalogNavigations = new List<CatalogNavigationDto>();
            Nivosliders = new List<NivosliderDto>();
            Keywords = new List<KeywordDto>();
        }

        [JsonProperty("Activitys")]
        public List<ActivityDto> Activitys { get; set; }

        [JsonProperty("CatalogNavigations")]
        public List<CatalogNavigationDto> CatalogNavigations { get; set; }

        [JsonProperty("Nivosliders")]
        public List<NivosliderDto> Nivosliders { get; set; }

        [JsonProperty("Keywords")]
        public List<KeywordDto> Keywords { get; set; }

        [JsonObject(Title = "Activity")]
        public class ActivityDto
        {
            [JsonProperty("Picture")]
            public PictureDto Picture { get; set; }

            [JsonProperty("Link")]
            public string Link { get; set; }
        }

        [JsonObject(Title = "CatalogNavigation")]
        public class CatalogNavigationDto
        {
            [JsonProperty("Picture")]
            public PictureDto Picture { get; set; }

            [JsonProperty("Text")]
            public string Text { get; set; }

            [JsonProperty("Link")]
            public string Link { get; set; }
        }

        [JsonObject(Title = "Nivoslider")]
        public class NivosliderDto
        {
            [JsonProperty("Picture")]
            public PictureDto Picture { get; set; }

            [JsonProperty("Text")]
            public string Text { get; set; }

            [JsonProperty("Link")]
            public string Link { get; set; }
        }

        [JsonObject(Title = "Keyword")]
        public class KeywordDto
        {
            [JsonProperty("Text")]
            public string Text { get; set; }

            [JsonProperty("Link")]
            public string Link { get; set; }
        }


     
    }
}
