using Autofac;
using Nop.Admin.Controllers;
using Nop.Core.Configuration;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.DependencyManagement;
using Nop.Plugin.Other.Client.Controllers;
using Nop.Plugin.Other.Client.Infrastructure.Converters;
using Nop.Plugin.Other.Client.Infrastructure.Helpers;
using Nop.Plugin.Other.Client.Infrastructure.Json.Serializers;

namespace Nop.Plugin.Widgets.NivoSlider.Infrastructure
{
    /// <summary>
    /// Dependency registrar
    /// </summary>
    public class DependencyRegistrar : IDependencyRegistrar
    {
        /// <summary>
        /// Register services and interfaces
        /// </summary>
        /// <param name="builder">Container builder</param>
        /// <param name="typeFinder">Type finder</param>
        /// <param name="config">Config</param>
        public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder, NopConfig config)
        {
            //controller
            builder.RegisterType<Other.Client.Controllers.SettingController>().InstancePerLifetimeScope();
            


            //api controller
            builder.RegisterType<ConfigApiController>().InstancePerLifetimeScope();
            builder.RegisterType<CatalogApiController>().InstancePerLifetimeScope();


            builder.RegisterType<JsonFieldsSerializer>().As<IJsonFieldsSerializer>().InstancePerLifetimeScope();
            builder.RegisterType<WebConfigMangerHelper>().As<IWebConfigMangerHelper>().InstancePerLifetimeScope();
            builder.RegisterType<ObjectConverter>().As<IObjectConverter>().InstancePerLifetimeScope();
            builder.RegisterType<ApiTypeConverter>().As<IApiTypeConverter>().InstancePerLifetimeScope();
        }

        /// <summary>
        /// Order of this dependency registrar implementation
        /// </summary>
        public int Order
        {
            get { return 2; }
        }
    }
}
