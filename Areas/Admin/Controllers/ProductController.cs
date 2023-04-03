﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using ShoeStore.Models;

namespace ShoeStore.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Admin/Product
        
        public ActionResult Manager()
        {
            ShoeStoreEntities db = new ShoeStoreEntities();
            var ListProduct = db.GetProducts(null, null);
            ViewBag.Products = ListProduct;
            return View();
        }
        public ActionResult ThemSanPham()
        {
            ShoeStoreEntities db = new ShoeStoreEntities();
            var ListProduct = db.GetProducts(null, null);
            ViewBag.them = ListProduct;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThemSanPham([Bind(Include = "ProductName, ProductPrice, ProductCategory, Description")]GetProductDetail_Result product)
        {
            ShoeStoreEntities db = new ShoeStoreEntities();
            db.InsertProduct(product.ProductName, product.ProductPrice, product.ProductCategory, product.Description);
            db.SaveChanges();
            return RedirectToAction("Manager");
        }
      
        public ActionResult SuaSanPham(int? id)
        {
            ShoeStoreEntities db = new ShoeStoreEntities();
            var ListProduct = db.GetProductDetail(id).Single();
            ViewBag.sua = ListProduct;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SuaSanPham()
        {
            int Id = int.Parse( Request.Form["ProductID"]);
            var Name = Request.Form["ProductName"];
            double Price = double.Parse(Request.Form["ProductPrice"]);
            int Cate = int.Parse(Request.Form["ProductCategory"]);
            var Des = Request.Form["Description"];
            ShoeStoreEntities db = new ShoeStoreEntities();
            db.UpdateProduct(Id,Name,Price,Cate,Des);
            db.SaveChanges();
            return RedirectToAction("Manager");
        }

        public ActionResult XoaSanPham(int? id)
        {
            ShoeStoreEntities db = new ShoeStoreEntities();
            var ListProduct = db.GetProductDetail(id).Single();
            ViewBag.xoa = ListProduct;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult XoaSanPham(int id)
        {
            int Id = int.Parse(Request.Form["ProductID"]);
            ShoeStoreEntities db = new ShoeStoreEntities();
            db.DeleteProduct(Id);
            db.SaveChanges();
            return RedirectToAction("Manager");
        }

    }
}