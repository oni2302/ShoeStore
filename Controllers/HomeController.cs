using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoeStore.Models;

namespace ShoeStore.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ShoeStoreEntities db = new ShoeStoreEntities();
            var newest = db.GetProducts(null, "newest").ToList();
            ViewBag.NewestProducts = newest;
            var trending = db.GetProducts(null, "trending").ToList();
            ViewBag.TrendingProducts = trending;
            return View();
        }
    }
}