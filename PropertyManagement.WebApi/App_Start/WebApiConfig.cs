namespace PropertyManagement.WebApi
{
    using System.Web.Http;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            var cors = new System.Web.Http.Cors.EnableCorsAttribute(origins: "*", headers: "*", methods: "*");
            config.EnableCors(cors);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "BuildingUnitsApiRoute",
                routeTemplate: "api/building/{buildingId}/units/{unitId}",
                defaults: new { controller = "BuildingUnits", unitId = RouteParameter.Optional });
        }
    }
}
