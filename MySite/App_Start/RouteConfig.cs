using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MySite
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();

           
             
            routes.MapRoute(
                name: "Search",
                url: "Search/{action}/{id}",
                defaults: new { controller = "Search", action = "Search", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "SearchBasic",
                url: "Search/{action}/{searchtype}/{searchstring}",
                defaults: new { controller = "Search", action = "Search", searchtype = UrlParameter.Optional, searchstring = UrlParameter.Optional }
            );

             routes.MapRoute(
                name: "Location",
                url: "Location/{action}",
                defaults: new { controller = "Location", action = "LocationActionResult"}
            );
             routes.MapRoute(
              name: "Landlord",
              url: "Landlord/{action}/{id}",
              defaults: new { controller = "Landlord", action = "LandlordHome", id = UrlParameter.Optional }
          );
             routes.MapRoute(
              name: "MyListings",
              url: "MyListings/{action}/{id}",
              defaults: new { controller = "Listing", action = "MyListings", id = UrlParameter.Optional }
          );
             routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
