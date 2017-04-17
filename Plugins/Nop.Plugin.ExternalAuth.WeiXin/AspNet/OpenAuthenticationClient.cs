using System;
using System.Collections.Generic;
using System.Web;
using DotNetOpenAuth.AspNet;
using Nop.Core.Infrastructure;

namespace Nop.Plugin.ExternalAuth.WeiXin.AspNet
{
    public abstract class OpenAuthenticationClient : IAuthenticationClient
    {
        private readonly string _providerName;

        protected OpenAuthenticationClient(string providerName)
        {
            _providerName = providerName;
        }

        /// <summary>
        /// 获得用户信息
        /// </summary>
        /// <param name="openIdData">取用户信息的链接地址参数</param>
        /// <returns>用户信息</returns>
        protected abstract IDictionary<string, string> GetUserData(object openIdData);

        /// <summary>
        /// 根据授权服务器返回的Code取Access_token
        /// </summary>
        /// <param name="authorizationCode">授权服务器返回的code</param>
        /// <returns>Access_token值</returns>
        protected abstract IDictionary<string, string> QueryAccessToken(object authorizationCode);

        public void RequestAuthentication(HttpContextBase context, Uri returnUrl) { }

        /// <summary>
        /// 授权验证
        /// </summary>
        public AuthenticationResult VerifyAuthentication(HttpContextBase context)
        {
            string name;
            string code = context.Request.QueryString["code"];
            //EngineContext.Current.Resolve<ILogger>().InsertLog(LogLevel.Information, "code:", code);
            if (string.IsNullOrEmpty(code))
            {
                return AuthenticationResult.Failed;
            }

            var requestCount = EngineContext.Current.Resolve<WeiXinExternalAuthSettings>().RequestCount; // 尝试与服务器交互的次数
            //IDictionary<string, string> openIdData = this.QueryAccessToken(code);
            IDictionary<string, string> openIdData = ApiCall.TryCallServer(QueryAccessToken, code, requestCount);

            if (openIdData == null || string.IsNullOrEmpty(openIdData["access_token"]))
            {
                return AuthenticationResult.Failed;
            }

            //IDictionary<string, string> userData = this.GetUserData(openIdData);
            IDictionary<string, string> userData = ApiCall.TryCallServer(GetUserData, openIdData, requestCount);
            if (userData == null)
            {
                return AuthenticationResult.Failed;
            }

            string providerUserId = openIdData["open_id"];
            if (!userData.TryGetValue("nick_name", out name))
            {
                name = providerUserId;
            }
            userData.Add("access_token", openIdData["access_token"]);
            userData.Add("id", openIdData["open_id"]);
            userData.Add("email", openIdData["open_id"] + "@weixin.com");

            return new AuthenticationResult(true, ProviderName, providerUserId, name, userData);
        }

        public string ProviderName
        {
            get { return _providerName; }
        }
    }
}
