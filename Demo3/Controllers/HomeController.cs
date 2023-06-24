using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo3.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Trangchu()
        {
            //1Chuyen huong qua Action khac cung controller
            //return RedirectToAction("DangNhap");

            //2chuyen huong khac controller
            //return RedirectToAction("Danhsachtintuc", "Tintuc");

            //3.chuyen huong bang url
            //return Redirect("https://google.com");

            //4.Chuyen huong bang App_Star -> RouteConfig -> routeName
            //return RedirectToRoute("Default");

            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
      
    }
}