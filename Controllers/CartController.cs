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
    public class CartController : Controller
    {
        ShoeStoreEntities db = new ShoeStoreEntities();
        // GET: ShoppingCart
        public ActionResult Index()
        {
            List<CartProduct> ShoppingCart = Session[CommonConstants.CART_SESSION] as List<CartProduct>;
            return View();
        }
        [HttpPost]
        public string AddToCart()
        {
            int id = int.Parse(Request.Form["id"]);
            Carts carts = new Carts();


            //Kiểm tra có user đăng nhập hay chưa
            if (Session[CommonConstants.USER_SESSION]!=null)
            {

            }
















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
            return "Đã thêm";
        }
           
        public RedirectToRouteResult UpdateAmount(int ProductId, int newAmount)
        {
            // tìm carditem muon sua
            List<CartProduct> ShoppingCart = Session[CommonConstants.CART_SESSION] as List<CartProduct>;
            CartProduct EditAmount = ShoppingCart.FirstOrDefault(m => m.ProductId == ProductId);
            if (EditAmount != null)
            {
                EditAmount.Quantity = newAmount;
            }
            return RedirectToAction("Index");
        }
        public RedirectToRouteResult RemoveItem(int ProductId)
        {
            List<CartProduct> shoppingCart = Session[CommonConstants.CART_SESSION] as List<CartProduct>;
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