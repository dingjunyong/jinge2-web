using Newtonsoft.Json;

namespace Nop.Plugin.ExternalAuth.WeiXin.AspNet
{
    public class WeiXinOpenIdData
    {
        /// <summary>
        /// 授权用户唯一标识
        /// </summary>
        [JsonProperty("openid")]
        public string OpenId { get; set; }

        /// <summary>
        /// 接口调用凭证
        /// </summary>
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
    }
}
