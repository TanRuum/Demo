using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDemo2.Models;
using WebDemo2.App_Start;
namespace WebDemo2.Areas.Admin.Controllers
{
    public class NhanVienController : Controller
    {
        [AdminAuthorize(IdChucNang = 1)]
        public ActionResult DanhSach()
        {
            return View();
        }
        [AdminAuthorize(IdChucNang = 2)]
        public ActionResult ThemMoi()
        {
            return View();
        }
        [AdminAuthorize(IdChucNang = 3)]
        public ActionResult CapNhat()
        {
            return View();
        }
        [AdminAuthorize(IdChucNang = 4)]
        public ActionResult Xoa()
        {
            return View();
        }
    }
}