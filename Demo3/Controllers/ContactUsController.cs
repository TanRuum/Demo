using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo3.Models;
namespace Demo3.Controllers
{
    public class ContactUsController : Controller
    {
        // GET: ContactUs
        public ActionResult Index()
        {
            var ds5may = new MayTinh().Hienthi();
            return View(ds5may);
        }

        public ActionResult Sapxep()
        {
            var ds2MayTinh = new MayTinh().Hienthi().OrderBy(m => m.Price).Take(2).ToList();
            return View(ds2MayTinh);
        }
        public ActionResult SapxepTuBeDenLon()
        {
            var Sapxeptang = new MayTinh().Hienthi().OrderBy(m => m.Price).ToList();
            return View(Sapxeptang);
        }
        public ActionResult SapxepLonDenBe()
        {
            var Sapxepgiamdan = new MayTinh().Hienthi().OrderByDescending(m => m.Price).ToList();
            return View(Sapxepgiamdan);
        }
        public ActionResult TimhangApple()
        {
            var TimhangmayApple = new MayTinh().Hienthi().Where(m => m.HangSX=="Apple").ToList();
            return View(TimhangmayApple);
        }
    }
}


//var Sapxepgiam = new MayTinh().Hienthi().OrderByDescending(m => m.Price).ToList();
