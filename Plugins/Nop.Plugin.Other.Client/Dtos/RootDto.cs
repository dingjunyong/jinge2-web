using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Other.Client.Dtos
{
    public class RootDto
    {
        [JsonProperty("Code")]
        public HttpStatusCode Code { get; set; }

        [JsonProperty("Data")]
        public Object Data { get; set; }

        [JsonProperty("Message")]
        public string Message { get; set; }
    }
}
