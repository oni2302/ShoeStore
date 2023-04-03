using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoeStore.Common;
using ShoeStore.Entities;
using ShoeStore.Models;

namespace ShoeStore.Controllers
{
    public class ShoppingCartController : Controller
    {
        ShoeStoreEntities db = new ShoeStoreEntities();
        // GET: ShoppingCart
        public ActionResult Index()
        {
            List<CartProduct> ShoppingCart = Session["ShoppingCart"] as List<CartProduct>;
            return View();
        }
        public RedirectToRouteResult AddToCart(int id)
        {
            // Tạo giỏ hàng rỗng
            Carts carts = new Carts();  
            if (Session[CommonConstants.CART_SESSION] == null)
            {
                Session.Add(CommonConstants.USER_SESSION, carts);
            }
            else
            {
                carts = Session[CommonConstants.CART_SESSION] as Carts;
            }
            var data = db.GetProductDetail(id).Single();
            CartProduct cartProduct = new CartProduct(1,data.ProductId,data.ProductName,new byte[1],(double)(data.ProductPrice));
            int kiemtra = carts.KiemTraGioHang(cartProduct);
            if (kiemtra==-1)
            {
                carts.products.Add(cartProduct);
            }
            else
            {
                carts.products[kiemtra].Quantity++;
            }
            Session[CommonConstants.CART_SESSION] = carts;
            return RedirectToRoute("GioHang");
        }
           
        public RedirectToRouteResult UpdateAmount(int ProductId, int newAmount)
        {
            // tìm carditem muon sua
            List<CartProduct> ShoppingCart = Session["ShoppingCart"] as List<CartProduct>;
            CartProduct EditAmount = ShoppingCart.FirstOrDefault(m => m.ProductId == ProductId);
            if (EditAmount != null)
            {
                EditAmount.Quantity = newAmount;
            }
            return RedirectToAction("Index");
        }
        public RedirectToRouteResult RemoveItem(int ProductId)
        {
            List<CartProduct> shoppingCart = Session["ShoppingCart"] as List<CartProduct>;
            CartProduct DelItem = shoppingCart.FirstOrDefault(m => m.ProductId == ProductId);
            if (DelItem != null)
            {
                shoppingCart.Remove(DelItem);
            }
            return RedirectToAction("Index");
        }

        public ActionResult ThanhToan()
        {
            return View();
        }
        
    }
}