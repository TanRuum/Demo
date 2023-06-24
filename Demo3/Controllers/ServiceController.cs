using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo3.Models;


namespace Demo3.Controllers
{
    public class ServiceController : Controller
    {
        // GET: Service
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Text()
        {
            //var classdsmaytinh = new DsMayTinh();

            //DsMayTinh.Danhsach.Add(new MayTinh()
            //{
            //    Mamay = "12015546210",
            //    Tendongmay = "Asus231564",
            //    Price = "18.000.000đ",
            //    NSX = new DateTime(2021, 09, 30),
            //    HangSX = "Asus"

            //});
            //var ds5may = DsMayTinh.Danhsach;
            return View(DsMayTinh.Danhsach);
        }
        public ActionResult FormThemMoi()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LuuThemMoi(string Mamay, string Tendongmay, double Price, DateTime NSX, string HangSX)
        {
            DsMayTinh.Danhsach.Add(new MayTinh()
            {
                Mamay = Mamay,
                Tendongmay = Tendongmay,
                Price = Price,
                NSX = NSX,
                HangSX = HangSX
            });
            return RedirectToAction("Text");

        }
        public ActionResult FormThemMoi2()
        {
            return View();
        }
        public ActionResult Themmoi2()
        {

            return View(new MayTinh()
            {
                NSX = DateTime.Now,
            });
        }
        [HttpPost]

        public ActionResult Themmoi2(MayTinh model)
        {
            //Cách add 2
            //DsMayTinh.Danhsach.Add(new MayTinh()
            //{
            //    Mamay = model.Mamay,
            //    Tendongmay = model.Tendongmay,
            //    Price = model.Price,
            //    NSX = model.NSX,
            //    HangSX = model.HangSX
            //});

            //Cách add 3
            if (ModelState.IsValid == true)
            {
                DsMayTinh.Danhsach.Add(model);
                return RedirectToAction("Text");
            }
            else
            {
                ModelState.AddModelError("", "Bạn chưa nhập dữ liệu");
                return View(model);

            }

        }
    }
}