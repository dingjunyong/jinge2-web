using System.Web.Routing;
using Nop.Core.Plugins;
using Nop.Services.Localization;
using Nop.Services.Configuration;
using Nop.Services.Authentication.External;

namespace Nop.Plugin.ExternalAuth.WeiXin
{
    public class WeiXinExternalAuthMethod : BasePlugin, IExternalAuthenticationMethod
    {
        private readonly ISettingService _settingService;

        public WeiXinExternalAuthMethod(ISettingService settingService)
        {
            _settingService = settingService;
        }

        public void GetConfigurationRoute(out string actionName, out string controllerName, out RouteValueDictionary routeValues)
        {
            actionName = "Configure";
            controllerName = "ExternalAuthWeiXin";
            routeValues = new RouteValueDictionary() { { "Namespaces", "Nop.Plugin.ExternalAuth.WeiXin.Controllers" }, { "area", null } };
        }

        public void GetPublicInfoRoute(out string actionName, out string controllerName, out RouteValueDictionary routeValues)
        {
            actionName = "PublicInfo";
            controllerName = "ExternalAuthWeiXin";
            routeValues = new RouteValueDictionary() { { "Namespaces", "Nop.Plugin.ExternalAuth.WeiXin.Controllers" }, { "area", null } };
        }

        public override void Install()
        {
            // settings
            var settings = new WeiXinExternalAuthSettings()
            {
                AppId = "",
                AppSecret = "",
                RequestCount = 3
            };
            _settingService.SaveSetting(settings);

            // locales
            this.AddOrUpdatePluginLocaleResource("Plugins.ExternalAuth.WeiXin.Login", "微信登录");
            this.AddOrUpdatePluginLocaleResource("Plugins.ExternalAuth.WeiXin.AppId", "AppId");
            this.AddOrUpdatePluginLocaleResource("Plugins.ExternalAuth.WeiXin.AppId.Hint", "应用唯一标识，在微信开放平台提交应用审核通过后获得");
            this.AddOrUpdatePluginLocaleResource("Plugins.ExternalAuth.WeiXin.AppSecret", "AppSecret");
            this.AddOrUpdatePluginLocaleResource("Plugins.ExternalAuth.WeiXin.AppSecret.Hint", "应用密钥AppSecret，在微信开放平台提交应用审核通过后获得");
            this.AddOrUpdatePluginLocaleResource("Plugins.ExternalAuth.WeiXin.RequestCount", "交互次数");
            this.AddOrUpdatePluginLocaleResource("Plugins.ExternalAuth.WeiXin.RequestCount.Hint", "尝试与微信服务器的交互次数，用于增加插件稳定性，建议为3");

            // validators
            this.AddOrUpdatePluginLocaleResource("Plugins.ExternalAuth.WeiXin.AppId.Validator", "请填写AppId");
            this.AddOrUpdatePluginLocaleResource("Plugins.ExternalAuth.WeiXin.AppSecret.Validator", "请填写AppSecret");
            this.AddOrUpdatePluginLocaleResource("Plugins.ExternalAuth.WeiXin.RequestCount.Validator", "交互次数最小值为1");

            base.Install();
        }

        public override void Uninstall()
        {
            // settings
            _settingService.DeleteSetting<WeiXinExternalAuthSettings>();

            // locales
            this.DeletePluginLocaleResource("Plugins.ExternalAuth.WeiXin.Login");
            this.DeletePluginLocaleResource("Plugins.ExternalAuth.WeiXin.AppId");
            this.DeletePluginLocaleResource("Plugins.ExternalAuth.WeiXin.AppId.Hint");
            this.DeletePluginLocaleResource("Plugins.ExternalAuth.WeiXin.AppSecret");
            this.DeletePluginLocaleResource("Plugins.ExternalAuth.WeiXin.AppSecret.Hint");
            this.DeletePluginLocaleResource("Plugins.ExternalAuth.WeiXin.RequestCount");
            this.DeletePluginLocaleResource("Plugins.ExternalAuth.WeiXin.RequestCount.Hint");
            //this.DeletePluginLocaleResource("Plugins.FriendlyName.ExternalAuth.WeiXin");

            // validators
            this.DeletePluginLocaleResource("Plugins.ExternalAuth.WeiXin.AppId.Validator");
            this.DeletePluginLocaleResource("Plugins.ExternalAuth.WeiXin.AppSecret.Validator");
            this.DeletePluginLocaleResource("Plugins.ExternalAuth.WeiXin.RequestCount.Validator");

            base.Uninstall();
        }
    }
}
