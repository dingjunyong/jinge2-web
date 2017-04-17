using FluentValidation;
using Nop.Core.Infrastructure;
using Nop.Plugin.ExternalAuth.WeiXin.Models;
using Nop.Services.Localization;

namespace Nop.Plugin.ExternalAuth.WeiXin.Validators
{
    public class WeiXinConfigurationValidator:AbstractValidator<ConfigurationModel>
    {
        public WeiXinConfigurationValidator()
        {
            var localizationService = EngineContext.Current.Resolve<ILocalizationService>();
            RuleFor(x => x.AppId).NotEmpty().WithMessage(localizationService.GetResource("Plugins.ExternalAuth.WeiXin.AppId.Validator"));
            RuleFor(x => x.AppSecret).NotEmpty().WithMessage(localizationService.GetResource("Plugins.ExternalAuth.WeiXin.AppSecret.Validator"));
            RuleFor(x => x.RequestCount).GreaterThanOrEqualTo(1).WithMessage(localizationService.GetResource("Plugins.ExternalAuth.WeiXin.RequestCount.Validator"));
        }
    }
}
