using ShoeStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoeStore.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Home()
        {
            ShoeStoreEntities db = new ShoeStoreEntities();
            var newest = db.GetProducts(null,"newest").ToList();
            ViewBag.NewestProducts = newest;
            var trending = db.GetProducts(null, "trending").ToList();
            ViewBag.TrendingProducts = trending;
            return View();
        }
        [Route(Name = "SanPham")]
        public ActionResult List()
        {
            ShoeStoreEntities db = new ShoeStoreEntities();
            var product =db.GetProducts(null, null).ToList();
            ViewBag.Product = product;
            return View();
        }
        public ActionResult Details(int id)
        {
            ShoeStoreEntities db = new ShoeStoreEntities();
            var detail = db.GetProductDetail(id).Single();
            ViewBag.ProductDetail = detail;

            var size = db.GetSizeOfProduct(id);
            ViewBag.Size = size;
            var color = db.GetColorOfProduct(id);
            ViewBag.Color = color;
            return View();
        }
        
    }
}