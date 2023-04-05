using ShoeStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Protocols;

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
        public ActionResult List(string category)
        {
            ShoeStoreEntities db = new ShoeStoreEntities();
            var product =db.GetProducts(null, category).ToList();
            ViewBag.Category = (category!=null)?category:"Colection"+$" ({product.Count})";
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