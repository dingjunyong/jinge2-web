using Autofac;
using Nop.Core.Configuration;
using Nop.Plugin.ExternalAuth.WeiXin.Core;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.DependencyManagement;

namespace Nop.Plugin.ExternalAuth.WeiXin
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public void Register(ContainerBuilder builder, ITypeFinder typeFinder, NopConfig config)
        {
            builder.RegisterType<WeiXinProviderAuthorizer>().As<IOAuthProviderWeiXinAuthorizer>().InstancePerLifetimeScope();
        }

        public int Order
        {
            get { return 1; }
        }
    }
}
