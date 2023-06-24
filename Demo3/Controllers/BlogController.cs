using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo3.Helper;
using Demo3.Models;

namespace Demo3.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        public ActionResult Index()
        {
            // Cách 1:sử dụng viewbag. controller để truyền qua view
            MathHelp calculator = new MathHelp();
            ViewBag.A = calculator.tong(5, 10);
            //return View();
            // Cách 2: sử dụng tham số của hàm view
           ;

            List<Sinhvien> Danhsachsv = new List<Sinhvien>();
            var sv1 = new Sinhvien();
            sv1.Id = 1;
            sv1.MaSo = "001";
            sv1.HoTen = "Tran Hai Tan";
            Danhsachsv.Add(sv1);

            var sv2 = new Sinhvien();
            sv2.Id = 2;
            sv2.MaSo = "002";
            sv2.HoTen = "Nguyen Van Teo";
            Danhsachsv.Add(sv2);

            return View(Danhsachsv);


        }
    }
}