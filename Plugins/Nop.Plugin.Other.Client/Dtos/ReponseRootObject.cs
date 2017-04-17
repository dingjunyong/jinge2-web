using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Other.Client.Dtos
{
    public class ReponseRootObject : ISerializableObject
    {


        [JsonProperty("Root")]
        public RootDto Root { get; set; }

        public string GetPrimaryPropertyName()
        {
            return "Root";
        }

        public Type GetPrimaryPropertyType()
        {
            return typeof(RootDto);
        }
    }
}
