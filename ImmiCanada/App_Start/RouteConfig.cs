using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ImmiCanada
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "DichVu",
                url: "dich-vu",
                defaults: new
                {
                    controller = "Service",
                    action = "Index"
                }
            );

            routes.MapRoute(
                name: "ChiTietDichVu",
                url: "dich-vu/{state}/{service_name}/{id}",
                defaults: new
                {
                    controller = "Service",
                    action = "Detail",
                    id = UrlParameter.Optional
                }
            );

            routes.MapRoute(
                name: "DanhSachViecLam",
                url: "viec-lam-canada",
                defaults: new
                {
                    controller = "WorkInterface",
                    action = "Search",
                    id = UrlParameter.Optional
                }
            );

            routes.MapRoute(
                name: "WorkPermit",
                url: "viec-lam-canada/{work_permit}",
                defaults: new
                {
                    controller = "WorkInterface",
                    action = "WorkPermit",
                    id = UrlParameter.Optional
                }
            );

            routes.MapRoute(
                name: "ChiTietViecLam",
                url: "viec-lam-canada/{job_name}/{id}",
                defaults: new
                {
                    controller = "WorkInterface",
                    action = "Detail",
                    id = UrlParameter.Optional
                }
            );

            

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            //routes.MapRoute(
            //    name: "Service",
            //    url: "dich-vu/{category_name}/{Post_name}/{id}",
            //    defaults: new
            //    {
            //        controller = "Service",
            //        action = "Index",
            //        category_name = UrlParameter.Optional,
            //        Post_name = UrlParameter.Optional,
            //        id = UrlParameter.Optional
            //    }
            //);
        }
    }
}
