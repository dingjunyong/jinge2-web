using Nop.Plugin.ExternalAuth.WeiXin.Validators;
using Nop.Web.Framework;
using Nop.Web.Framework.Mvc;

namespace Nop.Plugin.ExternalAuth.WeiXin.Models
{
    [FluentValidation.Attributes.Validator(typeof(WeiXinConfigurationValidator))]
    public class ConfigurationModel : BaseNopModel
    {
        public int ActiveStoreScopeConfiguration { get; set; }

        [NopResourceDisplayName("Plugins.ExternalAuth.WeiXin.AppId")]
        public string AppId { get; set; }
        public bool AppIdOverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.ExternalAuth.WeiXin.AppSecret")]
        public string AppSecret { get; set; }
        public bool AppSecretOverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.ExternalAuth.WeiXin.RequestCount")]
        public int RequestCount { get; set; }
        public bool RequestCountOverrideForStore { get; set; }
    }
}
