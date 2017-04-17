using Nop.Web.Framework.Mvc.Routes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;

namespace Nop.Plugin.Other.Client
{
    public class RouteProvider : IRouteProvider
    {
       
        public void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute("Plugin.Api.Settings",
                "Plugins/Setting/Mobile",
                new { controller = "Setting", action = "Mobile", },
                new[] { "Nop.Plugin.Other.Client.Controllers" }
           );

        }
        public int Priority
        {
            get { return 0; }
        }


    }
}
