using System;
using System.Configuration;
using System.Web.Http;
using System.Web.Routing;
using SimpleInjector;

namespace AutofacWebApi
{
    public class Global : System.Web.HttpApplication
    {

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.Ignore("{resource}.axd/{*pathInfo}");

            routes.MapHttpRoute(
                name: "IdWithExt",
                routeTemplate: "api/{controller}.{ext}");

            routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(RouteTable.Routes);


            // Create the container as usual.
            var container = new Container();

            var services = GlobalConfiguration.Configuration.Services;
            var controllerTypes = services.GetHttpControllerTypeResolver()
                .GetControllerTypes(services.GetAssembliesResolver());

            // register Web API controllers (important! http://bit.ly/1aMbBW0)
            foreach (var controllerType in controllerTypes)
            {
                container.Register(controllerType);
            }

            // Register your types, for instance:
            var connection = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;

            container.Register<IPrognoseRepository>(() => new PrognoseSqlRepository(connection));

            // Verify the container configuration
            container.Verify();

            // Register the dependency resolver.
            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
        }

    }
}