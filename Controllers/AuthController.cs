using ShoeStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoeStore.Controllers
{
    public class AuthController : Controller
    {
        // GET: Login
        ShoeStoreEntities db = new ShoeStoreEntities();

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

        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(UserReg_Result user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //db.RegValid(user.username, user.pass, user.email, user.sdt, user.diachi, user.tenkh).ToString();
                    return RedirectToRoute("Dangnhap");
                }
                catch (Exception)
                {
                    ModelState.AddModelError("SignupFailed", "Tên tài khoản đã tồn tại !");
                }
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