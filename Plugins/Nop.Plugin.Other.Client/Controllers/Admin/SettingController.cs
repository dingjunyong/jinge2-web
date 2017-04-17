
using System.Web.Mvc;
using Nop.Core;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Media;
using Nop.Services.Stores;
using Nop.Admin.Controllers;
using Nop.Services.Security;
using Nop.Plugin.Other.Client.Domain.Mobiles;
using Nop.Plugin.Other.Client.Models;
using Nop.Services.Logging;
using Nop.Plugin.Other.Client.Extensions;
using Nop.Web.Framework.Controllers;
using Nop.Plugin.Other.Client.Infrastructure.Constants;

namespace Nop.Plugin.Other.Client.Controllers
{
    [AdminAuthorize]
    public class SettingController : BaseAdminController
    {
        #region Fields

        private readonly ISettingService _settingService;
        private readonly IPictureService _pictureService;
        private readonly ILocalizationService _localizationService;
        private readonly IStoreService _storeService;
        private readonly IWorkContext _workContext;
        private readonly ILanguageService _languageService;
        private readonly ILocalizedEntityService _localizedEntityService;
        private readonly IPermissionService _permissionService;
        private readonly ICustomerActivityService _customerActivityService;
        #endregion

        #region Ctor

        public SettingController(ISettingService settingService,
            IPictureService pictureService,
            ILocalizationService localizationService,  
            IStoreService storeService,
            IWorkContext workContext,       
            ILanguageService languageService,
            ILocalizedEntityService localizedEntityService,
            IPermissionService permissionService,
            ICustomerActivityService customerActivityService)
        {
            this._settingService = settingService;      
            this._pictureService = pictureService;
            this._localizationService = localizationService;
            this._storeService = storeService;
            this._workContext = workContext;
            this._languageService = languageService;
            this._localizedEntityService = localizedEntityService;
            this._permissionService = permissionService;
            this._customerActivityService = customerActivityService;
        }

        #endregion

        [HttpGet]
        public virtual ActionResult Mobile()
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageSettings))
                return AccessDeniedView();

            var storeScope = this.GetActiveStoreScopeConfiguration(_storeService, _workContext);
            var mobileActivitySettings = _settingService.LoadSetting<MobileActivitySettings>(storeScope);
            var mobileCatalogNavigationSettings = _settingService.LoadSetting<MobileCatalogNavigationSettings>(storeScope);
            var mobileNivosliderSettings = _settingService.LoadSetting<MobileNivosliderSettings>(storeScope);
            var mobileKeywordSettings = _settingService.LoadSetting<MobileKeywordSettings>(storeScope);


            //merge settings
            var model = new MobileSettingsModel();
            model.MobileActivitySettings = mobileActivitySettings.ToModel();
            model.MobileCatalogNavigationSettings = mobileCatalogNavigationSettings.ToModel();
            model.MobileNivosliderSettings = mobileNivosliderSettings.ToModel();
            model.MobileKeywordSettings = mobileKeywordSettings.ToModel();



            return View(ViewNames.AdminMobileSettings, model);
        }
        [HttpPost]
        public virtual ActionResult Mobile(MobileSettingsModel model)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageSettings))
                return AccessDeniedView();


            var storeScope = this.GetActiveStoreScopeConfiguration(_storeService, _workContext);
            var mobileActivitySettings = _settingService.LoadSetting<MobileActivitySettings>(storeScope);
            var mobileCatalogNavigationSettings = _settingService.LoadSetting<MobileCatalogNavigationSettings>(storeScope);
            var mobileNivosliderSettings = _settingService.LoadSetting<MobileNivosliderSettings>(storeScope);
            var mobileKeywordSettings = _settingService.LoadSetting<MobileKeywordSettings>(storeScope);

            mobileActivitySettings = model.MobileActivitySettings.ToEntity(mobileActivitySettings);
            _settingService.SaveSetting(mobileActivitySettings);

            mobileCatalogNavigationSettings = model.MobileCatalogNavigationSettings.ToEntity(mobileCatalogNavigationSettings);
            _settingService.SaveSetting(mobileCatalogNavigationSettings);

            mobileNivosliderSettings = model.MobileNivosliderSettings.ToEntity(mobileNivosliderSettings);
            _settingService.SaveSetting(mobileNivosliderSettings);

            mobileKeywordSettings = model.MobileKeywordSettings.ToEntity(mobileKeywordSettings);
            _settingService.SaveSetting(mobileKeywordSettings);

            //activity log
            _customerActivityService.InsertActivity("EditSettings", _localizationService.GetResource("ActivityLog.EditSettings"));

            SuccessNotification(_localizationService.GetResource("Admin.Configuration.Updated"));

            //selected tab
            SaveSelectedTabName();

            return View(ViewNames.AdminMobileSettings, model);
        }
    }
}