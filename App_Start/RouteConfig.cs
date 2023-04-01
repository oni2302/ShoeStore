using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ShoeStore
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "",
                defaults: new { action = "Home", controller="Products" , id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "TrangChu",
                url: "trangchu/",
                defaults: new { action = "Home", controller = "Products", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "SanPham",
                url: "sanpham/loai/{id}",
                defaults: new { action = "List", controller = "Products", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "ChiTietSanPham",
                url: "sanpham/{id}/chitiet",
                defaults: new { action = "Details", controller = "Products", id = UrlParameter.Optional }
            );
        }
    }
}

