using Newtonsoft.Json;

namespace Nop.Plugin.ExternalAuth.WeiXin.AspNet
{
    public class WeiXinGraphData
    {
        [JsonProperty("nickname")]
        public string NickName { get; set; }

        [JsonProperty("sex")]
        public string Gender { get; set; }
    }
}
