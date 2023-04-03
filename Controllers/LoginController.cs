using ShoeStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoeStore.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        ShoeStoreEntities db = new ShoeStoreEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserReg_Result user)
        {
            var check = db.UserReg(user.username, user.pass).SingleOrDefault();

            if (check != null)
            {
                Session["User"] = user.username.ToString();
                return RedirectToRoute("TrangChu");
            }
            else
            {
                ModelState.AddModelError("LoginFailed", "Tên đăng nhập hoặc mật khẩu không đúng !");
            }
            return View();
        }
        public ActionResult Logout()
        {
            //Session["User"] = null;
            Session.Clear();
            return RedirectToRoute("Dangnhap");
        }
    }
}