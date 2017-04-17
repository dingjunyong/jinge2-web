using System;
using System.Web;
using System.Web.Mvc;
using DotNetOpenAuth.AspNet;
using Nop.Core;
using Nop.Plugin.ExternalAuth.WeiXin.AspNet;
using Nop.Services.Authentication.External;

namespace Nop.Plugin.ExternalAuth.WeiXin.Core
{
    public class WeiXinProviderAuthorizer : IOAuthProviderWeiXinAuthorizer
    {
        private readonly IExternalAuthorizer _authorizer;
        private readonly WeiXinExternalAuthSettings _weiXinExternalAuthSettings;
        private readonly HttpContextBase _httpContext;
        private readonly IWebHelper _webHelper;

        private WeiXinWebClient _weiXinApplication;

        public WeiXinProviderAuthorizer(IExternalAuthorizer authorizer,
            WeiXinExternalAuthSettings weiXinExternalAuthSettings,
            HttpContextBase httpContext, IWebHelper webHelper)
        {
            _authorizer = authorizer;
            _weiXinExternalAuthSettings = weiXinExternalAuthSettings;
            _httpContext = httpContext;
            _webHelper = webHelper;
        }

        private WeiXinWebClient WeiXinApplication
        {
            get { return _weiXinApplication ?? (_weiXinApplication = new WeiXinWebClient(_weiXinExternalAuthSettings.AppId, _weiXinExternalAuthSettings.AppSecret)); }
        }

        private AuthorizeState VerifyAuthentication(string returnUrl)
        {
            var authResult = WeiXinApplication.VerifyAuthentication(_httpContext);

            if (authResult.IsSuccessful)
            {
                if (!authResult.ExtraData.ContainsKey("id"))
                    throw new Exception("Authentication result does not contain id data");

                if (!authResult.ExtraData.ContainsKey("access_token"))
                    throw new Exception("Authentication result does not contain accesstoken data");

                var parameters = new OAuthAuthenticationParameters(Provider.SystemName)
                {
                    ExternalIdentifier = authResult.ProviderUserId,
                    OAuthToken = authResult.ExtraData["access_token"],
                    OAuthAccessToken = authResult.ProviderUserId
                };

                ParseClaims(authResult, parameters);

                var result = _authorizer.Authorize(parameters);
                return new AuthorizeState(returnUrl, result);
            }

            var state = new AuthorizeState(returnUrl, OpenAuthenticationStatus.Error);
            var error = authResult.Error != null ? authResult.Error.Message : "Unknown error";
            state.AddError(error);
            return state;
        }

        private void ParseClaims(AuthenticationResult authenticationResult, OAuthAuthenticationParameters parameters)
        {
            var claims = new UserClaims
            {
                Contact = new ContactClaims(),
                Person = new PersonClaims()
            };
            if (authenticationResult.ExtraData.ContainsKey("email"))
                claims.Contact.Email = authenticationResult.ExtraData["email"];
            //if (authenticationResult.ExtraData.ContainsKey("nick_name"))
            //    claims.Contact.Username = authenticationResult.ExtraData["nick_name"];
            if (authenticationResult.ExtraData.ContainsKey("gender"))
                claims.Person.Gender = authenticationResult.ExtraData["gender"];

            parameters.AddClaim(claims);
        }

        private AuthorizeState RequestAuthentication()
        {
            string loginCallbackUrl = HttpUtility.UrlEncode(string.Format("{0}Plugins/ExternalAuthWeiXin/LoginCallback", _webHelper.GetStoreLocation()));

            string authUrlPrefix = "https://open.weixin.qq.com/connect/qrconnect";

            string authUrl = string.Format("{0}?appid={1}&redirect_uri={2}&response_type=code&scope=snsapi_login&state={3}#wechat_redirect", authUrlPrefix, _weiXinExternalAuthSettings.AppId, loginCallbackUrl, GenerateNonceStr());

            return new AuthorizeState("", OpenAuthenticationStatus.RequiresRedirect) { Result = new RedirectResult(authUrl) };
        }

        /// <summary>
        /// 用于生成的随机数用于防御CSRF攻击
        /// </summary>
        /// <returns></returns>
        private string GenerateNonceStr()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }

        /// <summary>
        /// 授权验证
        /// </summary>
        /// <param name="returnUrl">用户输入的链接地址</param>
        /// <param name="verifyResponse"></param>
        public AuthorizeState Authorize(string returnUrl, bool? verifyResponse = null)
        {
            if (!verifyResponse.HasValue)
                throw new ArgumentException("WeiXin plugin cannot automatically determine verifyResponse property");

            return verifyResponse.Value ? VerifyAuthentication(returnUrl) : RequestAuthentication();
        }
    }
}
