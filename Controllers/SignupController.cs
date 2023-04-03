using ShoeStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoeStore.Controllers
{
    public class SignupController : Controller
    {
        ShoeStoreEntities db = new ShoeStoreEntities();
        // GET: Signup
        public ActionResult Index()
        {
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

    }
}