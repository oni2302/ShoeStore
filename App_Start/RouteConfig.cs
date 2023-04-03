using System;
using System.Collections.Generic;
using System.Data.Entity;
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
              name: "SanPham",
              url: "sanpham/loai/{id}",
              defaults: new
              {
                  action = "List",
                  controller = "Products",
                  id = UrlParameter.Optional
              }
            );
            routes.MapRoute(
              name: "ChiTietSanPham",
              url: "sanpham/{id}/chitiet",
              defaults: new
              {
                  action = "Details",
                  controller = "Products",
                  id = UrlParameter.Optional
              }
            );
            routes.MapRoute(
              name: "ThemGioHang",
              url: "themgiohang",
              defaults: new
              {
                  action = "AddToCart",
                  controller = "Cart"
              }
            );
            routes.MapRoute(
              name: "GioHang",
              url: "giohang",
              defaults: new
              {
                  action = "Index",
                  controller = "Cart",
                  id = UrlParameter.Optional
              }
            );
            routes.MapRoute(
              name: "ThanhToan",
              url: "ThanhToan",
              defaults: new
              {
                  action = "ThanhToan",
                  controller = "Cart",
                  id = UrlParameter.Optional
              }
            );

            routes.MapRoute(
              name: "Dangnhap",
              url: "Dangnhap",
              defaults: new
              {
                  action = "Login",
                  controller = "Login"
              }
            );
            routes.MapRoute(
              name: "Dangky",
              url: "Dangky",
              defaults: new
              {
                  action = "Signup",
                  controller = "Signup"
              }
            );
            routes.MapRoute(
              name: "DanhsachKH",
              url: "DanhsachKH",
              defaults: new
              {
                  action = "CustomerList",
                  controller = "QLKH"
              }
            );
            routes.MapRoute(
              name: "ThemKH",
              url: "ThemKH",
              defaults: new
              {
                  action = "AddCustomer",
                  controller = "QLKH"
              }
            );
            routes.MapRoute(
              name: "QLSP",
              url: "QLSP",
              defaults: new
              {
                  action = "Manager",
                  controller = "Product"
              }
            );
            routes.MapRoute(
              name: "ThemSP",
              url: "ThemSP",
              defaults: new
              {
                  action = "ThemSanPham",
                  controller = "Product"
              }
            );
            routes.MapRoute(
              name: "XoaSP",
              url: "XoaSP",
              defaults: new
              {
                  action = "XoaSanPham",
                  controller = "Product"
              }
            );
            routes.MapRoute(
              name: "SuaSP",
              url: "SuaSP",
              defaults: new
              {
                  action = "SuaSanPham",
                  controller = "Product"
              }
            );

            /* Ngoại lệ*/
            routes.MapRoute(
              name: "Default",
              url: "{controller}/{action}/{id}",
              defaults: new
              {
                  action = "Home",
                  controller = "Products",
                  id = UrlParameter.Optional
              });
        }
    }
}