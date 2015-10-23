using System.Web.Http;
using Owin;
using SelfHostProject.Services;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;

namespace SelfHostProject
{
    internal sealed class Startup
    {
        // This code configures Web API contained in the class Startup, which is additionally specified as the type
        // parameter in WebApplication.Start
        public void Configuration(IAppBuilder appBuilder)
        {
            // Add SimpeInjector package.
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();

            // Add SimpleInjector.Integration.WebApi package.
            container.Register<IValuesService, ValuesService>(new WebApiRequestLifestyle());

            // Configure Web API for Self-Host
            // HttpConfiguration located in Microsoft.AspNet.WebApi.Core package.
            HttpConfiguration config = new HttpConfiguration();

            // Add System.Web reference to avoid "Missing ..." error.
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);

            // UseWebApi extension method located in Microsoft.AspNet.WebApi.OwinSelfHost package.
            appBuilder.UseWebApi(config);
        }
    }
}