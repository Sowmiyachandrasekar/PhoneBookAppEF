using PhoneBook.DAL;
using PhoneBookWeb.BasicAuthN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Extensions;

namespace PhoneBookWeb
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //Odata
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Person>("OdataPerson");
            builder.EntitySet<City>("Cities");
            builder.EntitySet<Country>("Countries");
            builder.EntitySet<State>("States");
            config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());

            //Basic-AuthN
            config.Filters.Add(new BasicAuthenticationAttribute());

            //Enabling CORS
            config.EnableCors();


            // Web API configuration and services
            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
