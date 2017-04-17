using Nop.Core.Plugins;
using Nop.Core;
using Nop.Services.Localization;
using Nop.Web.Framework.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core.Infrastructure;
using Nop.Plugin.Other.Client.Infrastructure.Helpers;

namespace Nop.Plugin.Other.Client
{
    public class ClientPlugin : BasePlugin, IAdminMenuPlugin
    {
        private const string ControllersNamespace = "Nop.Plugin.Other.Client.Controllers";
        private readonly IWebConfigMangerHelper _webConfigMangerHelper;
        private ILocalizationService _localizationService;
        private IWebHelper _webHelper;
        private IWorkContext _workContext;

        protected ILocalizationService LocalizationService
        {
            get
            {
                if (_localizationService == null)
                {
                    _localizationService = EngineContext.Current.Resolve<ILocalizationService>();
                }

                return _localizationService;
            }
        }

        protected IWebHelper WebHelper
        {
            get
            {
                if (_webHelper == null)
                {
                    _webHelper = EngineContext.Current.Resolve<IWebHelper>();
                }

                return _webHelper;
            }
        }

        protected IWorkContext WorkContext
        {
            get
            {
                if (_workContext == null)
                {
                    _workContext = EngineContext.Current.Resolve<IWorkContext>();
                }

                return _workContext;
            }
        }


        public ClientPlugin(IWebConfigMangerHelper webConfigMangerHelper)
        {
            _webConfigMangerHelper = webConfigMangerHelper;
        }

        public override void Install()
        {
            
            //MENU
            this.AddOrUpdatePluginLocaleResource("Plugins.Other.Client.Admin.Menu.ManageClients", "客户端管理");
            this.AddOrUpdatePluginLocaleResource("Plugins.Other.Client.Admin.Menu.Title", "客户端管理");
            this.AddOrUpdatePluginLocaleResource("Plugins.Other.Client.Admin.Menu.Settings.Title", "手机客户端设置");

            base.Install();

            // Changes to Web.Config trigger application restart.
            // This doesn't appear to affect the Install function, but just to be safe we will made web.config changes after the plugin was installed.
            _webConfigMangerHelper.AddConfiguration();
        }

        public override void Uninstall()
        {
            //MENU
            this.DeletePluginLocaleResource("Plugins.Other.Client.Admin.Menu.ManageClients");
            this.DeletePluginLocaleResource("Plugins.Other.Client.Admin.Menu.Title");
            this.DeletePluginLocaleResource("Plugins.Other.Client.Admin.Menu.Settings.Title");

         

            base.Uninstall();

            // Changes to Web.Config trigger application restart.
            // This doesn't appear to affect the uninstall function, but just to be safe we will made web.config changes after the plugin was uninstalled.
            _webConfigMangerHelper.RemoveConfiguration();
        }
        public void ManageSiteMap(SiteMapNode rootNode)
        {
            string pluginMenuName = LocalizationService.GetResource("Plugins.Other.Client.Admin.Menu.Title", languageId: WorkContext.WorkingLanguage.Id, defaultValue: "客户端管理");

            string settingsMenuName = LocalizationService.GetResource("Plugins.Other.Client.Admin.Menu.Settings.Title", languageId: WorkContext.WorkingLanguage.Id, defaultValue: "手机客户端设置");


            const string adminUrlPart = "Plugins/";

            var pluginMainMenu = new SiteMapNode
            {
                Title = pluginMenuName,
                Visible = true,
                SystemName = "Client-Main-Menu",
                IconClass = "fa-genderless"
            };

            pluginMainMenu.ChildNodes.Add(new SiteMapNode
            {
                Title = settingsMenuName,
                Url = WebHelper.GetStoreLocation() + adminUrlPart + "Setting/Mobile",
                Visible = true,
                SystemName = "Client-Settings-Menu",
                IconClass = "fa-genderless"
            });



            rootNode.ChildNodes.Add(pluginMainMenu);
        }
       
    }

   
}
