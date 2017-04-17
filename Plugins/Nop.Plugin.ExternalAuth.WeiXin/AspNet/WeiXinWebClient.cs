using System.IO;
using System.Net;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nop.Plugin.ExternalAuth.WeiXin.AspNet
{
    public class WeiXinWebClient : OpenAuthenticationClient
    {
        //private const string AuthUrl = "https://open.weixin.qq.com/connect/qrconnect";
        private const string TokenUrl = "https://api.weixin.qq.com/sns/oauth2/access_token?appid={0}&secret={1}&code={2}&grant_type=authorization_code";
        private const string ApiUrl = "https://api.weixin.qq.com/sns/userinfo?access_token={0}&openid={1}&lang=zh_CN";

        private readonly string _appId;
        private readonly string _appSecret;

        public WeiXinWebClient(string appId, string appSecret)
            : base("WeiXin")
        {
            _appId = appId;
            _appSecret = appSecret;
        }

        protected override IDictionary<string, string> GetUserData(object openIdData)
        {
            var data = DictionaryExtensions.CastFrom<string, string>(openIdData);
            WebRequest webRequest = WebRequest.Create(string.Format(ApiUrl, data["access_token"], data["open_id"]));

            WeiXinGraphData weiXinGraphData = new WeiXinGraphData();
            using (WebResponse response = webRequest.GetResponse())
            {
                using (Stream responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        var streamReader = new StreamReader(responseStream);
                        var responseText = streamReader.ReadToEnd();
                        //EngineContext.Current.Resolve<ILogger>().InsertLog(LogLevel.Information, "responseText:", responseText);
                        weiXinGraphData = JsonConvert.DeserializeObject<WeiXinGraphData>(responseText);
                    }
                }
            }
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.AddItemIfNotEmpty("nick_name", weiXinGraphData.NickName);
            dictionary.AddItemIfNotEmpty("gender", weiXinGraphData.Gender == "1" ? "M" : "F");

            return dictionary;
        }

        protected override IDictionary<string, string> QueryAccessToken(object authorizationCode)
        {
            WebRequest webRequest = WebRequest.Create(string.Format(TokenUrl, _appId, _appSecret, authorizationCode as string));
            WeiXinOpenIdData weiXinOpenIdData = new WeiXinOpenIdData();
            using (WebResponse response = webRequest.GetResponse())
            {
                using (Stream responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        var streamReader = new StreamReader(responseStream);
                        var responseText = streamReader.ReadToEnd();
                        //EngineContext.Current.Resolve<ILogger>().InsertLog(LogLevel.Information, "responseText:", responseText);
                        weiXinOpenIdData = JsonConvert.DeserializeObject<WeiXinOpenIdData>(responseText);
                    }
                }
            }
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.AddItemIfNotEmpty("open_id", weiXinOpenIdData.OpenId);
            dictionary.AddItemIfNotEmpty("access_token", weiXinOpenIdData.AccessToken);

            return dictionary;
        }
    }
}
