using ShoeStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoeStore.Controllers
{
    public class UserController : Controller
    {
        ShoeStoreEntities db = new ShoeStoreEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            var customer = db.GetCustomer().ToList();
            ViewBag.CustomerList = customer;
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(UserReg_Result user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //db.RegValid(user.username, user.pass, user.email, user.sdt, user.diachi, user.tenkh).ToString();
                    return RedirectToAction("List");
                }
                catch (Exception)
                {
                    ModelState.AddModelError("CreateFailed", "Tên tài khoản đã tồn tại !");
                }
            }
            return View();
        }
    }
}