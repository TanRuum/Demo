using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebDemo2.Models;

namespace WebDemo2.Areas.Admin.Controllers
{
    public class HomeAdminController : Controller
    {
        //Cach 1

        public ActionResult Index()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            //check db
            BanHangEntities db = new BanHangEntities();
            var nhanvien = db.NhanViens.SingleOrDefault(m => m.Username.ToLower() == username.ToLower() && m.Password == password);

            //check code
            if (nhanvien != null)
            {
                Session["user"] = nhanvien;
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = "Tài khoản đăng nhập không đúng";
                return View();
            }
        }
        public ActionResult Logout()
        {


            //Xoa Session
            Session.Remove("user");
            Session.Abandon();

            FormsAuthentication.SignOut();
            //ngăn chặn việc lưu dữ cache
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.AppendCacheExtension("no-store, must-revalidate");
            return RedirectToAction("Login");
        }


        // Cách 2
        //public ActionResult Index()
        //{
        //    if (Session["user"] == null)
        //    {
        //        return RedirectToAction("Login");
        //    }
        //    else
        //    {
        //        return View();

        //    }
        //}
        //public ActionResult Login()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Login(string username, string password)
        //{
        //    //check db

        //    //check code
        //    if (username == "admin" && password == "123456")
        //    {
        //        Session["user"] = "admin";
        //        return RedirectToAction("Index");

        //    }
        //    else
        //    {
        //        TempData["error"] = "Tài khoản đăng nhập không đúng";
        //        return View();
        //    }
        //}
        //public ActionResult Logout()
        //{


        //    //Xoa Session
        //    Session.Remove("user");
        //    Session.Abandon();

        //    FormsAuthentication.SignOut();
        //    //ngăn chặn việc lưu dữ cache
        //    Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //    Response.Cache.AppendCacheExtension("no-store, must-revalidate");
        //    return RedirectToAction("Login");
        //}
    }
}