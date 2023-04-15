using ShoeStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoeStore.Common;
using ShoeStore.Entities;
using System.Drawing;
using System.IO;

namespace ShoeStore.Controllers
{
    public class AuthController : Controller
    {
        // GET: Login
        ShoeStoreEntities db = new ShoeStoreEntities();

        public ActionResult Login()
        {
            if (Session[CommonConstants.USER_SESSION] != null)
            {
                RedirectToRoute("trangchu");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username,string password)
        {
            var hashPassword = db.AuthenticateLogin(username).FirstOrDefault();
            if (PasswordOption.Validation(password,hashPassword))
            {
                var userSession = db.getUserSession(username).First();
                Session.Add(CommonConstants.USER_SESSION, userSession);
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
        [ValidateAntiForgeryToken]
        public ActionResult Signup([Bind(Include = "username, password, name, email, address, phone, file")] RegisterInfo registerInfo)
        {
            MemoryStream memoryStream = new MemoryStream();
            registerInfo.file.InputStream.CopyTo(memoryStream);
            byte[] buffer = memoryStream.ToArray(); 
            
            if (ModelState.IsValid)
            {
                var result = db.AuthenticateRegister(registerInfo.username, PasswordOption.Encrypt(registerInfo.password), registerInfo.name, registerInfo.email, registerInfo.phone, registerInfo.address, buffer).FirstOrDefault();
                if (result != "Đăng kí thành công")
                {
                    ModelState.AddModelError("SignupFailed", result + " !");
                }
                else
                {
                    return RedirectToRoute("Dangnhap");
                }       
            }
            return View();
        }





        public ActionResult Logout()
        {
            Session[CommonConstants.USER_SESSION] = null;
            return RedirectToRoute("Dangnhap");
        }
    }
}