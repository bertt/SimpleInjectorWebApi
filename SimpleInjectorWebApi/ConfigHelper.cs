using System.Web.Http;

namespace SimpleInjectorWebApi
{
    public static class ConfigHelper
    {
        public static HttpConfiguration GetHttpConfiguration()
        {
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute("Default", "api/{controller}/{id}", new { id = RouteParameter.Optional });
            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
            return config;
        }
    }
}