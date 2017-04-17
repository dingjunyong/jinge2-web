using Newtonsoft.Json;
using Nop.Plugin.Other.Client.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;

namespace Nop.Plugin.Other.Client.Dtos.Parameters
{
    [ModelBinder(typeof(ParametersBinder<SearchParamater>))]
    public class SearchParamater : PageParamater
    {
        [JsonProperty("q")]
        public string Q { get; set; }
    }
}
