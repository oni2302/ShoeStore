using ShoeStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoeStore.Controllers
{
    public class QLKHController : Controller
    {
        ShoeStoreEntities db = new ShoeStoreEntities();
        // GET: QLKH
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CustomerList()
        {
            var customer = db.GetCustomer().ToList();
            ViewBag.CustomerList = customer;
            return View();
        }

        public ActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCustomer(UserReg_Result user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //db.RegValid(user.username, user.pass, user.email, user.sdt, user.diachi, user.tenkh).ToString();
                    return RedirectToAction("CustomerList");
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