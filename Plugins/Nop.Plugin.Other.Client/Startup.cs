using Owin;
using System;
using System.Collections.Generic;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Owin;
using System.Web.Http;
using System.Web.Http.Filters;
using Nop.Core.Infrastructure;
using Nop.Services.Logging;
using Newtonsoft.Json;
using System.Web.Http.Routing;
using System.Net.Http;
using Autofac.Integration.WebApi;
using Nop.Plugin.Other.Client.Dtos;
using Nop.Plugin.Other.Client.Infrastructure.Json.ActionResults;
using System.Net;
using System.Threading;
using Nop.Plugin.Other.Client.Infrastructure.Json.Serializers;
using Nop.Plugin.Other.Client.OAuth.Providers;

[assembly: OwinStartup(typeof(Nop.Plugin.Other.Client.Startup))]

namespace Nop.Plugin.Other.Client
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
         {
            //ConfigureAuth(app);
            ConfigureWebApi(app);
        }

        private void ConfigureAuth(IAppBuilder app)
        {
            var OAuthOptions = new OAuthAuthorizationServerOptions
            {
                //在生产模式下设 AllowInsecureHttp = false
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/Token"),
                Provider = new AuthorisationServerProvider(),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
                //refresh token provider
                RefreshTokenProvider = new RefreshTokenProvider()
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            // 取消注释以下行可允许使用第三方登录提供程序登录
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //    consumerKey: "",
            //    consumerSecret: "");

            //app.UseFacebookAuthentication(
            //    appId: "",
            //    appSecret: "");

            //app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            //{
            //    ClientId = "",
            //    ClientSecret = ""
            //});
        }


        private void ConfigureWebApi(IAppBuilder app)
        {

            var config = new HttpConfiguration();
            config.Filters.Add(new ServerErrorHandlerAttribute());

            config.Formatters.JsonFormatter.SerializerSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };

            config.Routes.MapHttpRoute(
             name: "MobileHome",
             routeTemplate: "api/mobile/home",
             defaults: new { controller = "ConfigApi", action = "GetMobileHome" },
             constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) });

            config.Routes.MapHttpRoute(
             name: "HotSearchTerms",
             routeTemplate: "api/hot/searchterms",
             defaults: new { controller = "ConfigApi", action = "GetHotSearchTerms" },
             constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) });

            app.UseWebApi(config);

            config.DependencyResolver = new AutofacWebApiDependencyResolver(EngineContext.Current.ContainerManager.Container);

        }
    }

    public class ServerErrorHandlerAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception != null)
            {
                var jsonFieldsSerializer = EngineContext.Current.Resolve<IJsonFieldsSerializer>();

                var errors = "Please contact the store owner!";

                var logger = EngineContext.Current.Resolve<ILogger>();

                logger.Error(context.Exception.Message, context.Exception);

                var errorsRootObject = new ReponseRootObject()
                {
                    Root=new RootDto() { Code= HttpStatusCode.InternalServerError,Message= errors }
                };

                var errorsJson = jsonFieldsSerializer.Serialize(errorsRootObject, null);

                var errorResult = new ErrorActionResult(errorsJson, HttpStatusCode.InternalServerError);

                context.Response = errorResult.ExecuteAsync(new CancellationToken()).Result;
            }
        }
    }
}
