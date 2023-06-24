using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDemo1.Models;

namespace WebDemo1.Controllers
{
    public class DonHangController : Controller
    {

        // GET: DonHang

        public ActionResult ListOrder()
        {
            return View(DSDonHang.DanhsachDonHang);
        }
        public ActionResult AddNew()
        {
            return View(new DonHang());
        }
        [HttpPost]
        public ActionResult AddNew(DonHang model)
        {
            if (model.Id == 0)
            {
                ModelState.AddModelError("", "Bạn đã nhập sai hoặc thiếu ID");
                return View(model);
            }
            DSDonHang.DanhsachDonHang.Add(model);

            return RedirectToAction("ListOrder");
        }
        public ActionResult Eddit(int IdDonhang)
        {
            // Tìm ra ID cần sửa
            var Donhang = DSDonHang.DanhsachDonHang.SingleOrDefault(m => m.Id == IdDonhang);
            return View(Donhang);
        }
        [HttpPost]
        public ActionResult Eddit(DonHang model)
        {
            //Tìm Id cần sửa
            var DonHangMoi = DSDonHang.DanhsachDonHang.SingleOrDefault(m => m.Id == model.Id);
            DonHangMoi.Name = model.Name;
            DonHangMoi.Address = model.Address;
            DonHangMoi.OrderDate = model.OrderDate;
            DonHangMoi.PhoneNumber = model.PhoneNumber;
            return RedirectToAction("ListOrder");

        }

        public ActionResult Delete(int IdDonHang)
        {
            var DonHangMoi = DSDonHang.DanhsachDonHang.SingleOrDefault(m => m.Id == IdDonHang);
            DSDonHang.DanhsachDonHang.Remove(DonHangMoi);
            return RedirectToAction("ListOrder");

        }
        public ActionResult Detail(int IdDonHang)
        {
            var Chitiet = DSDonHang.DanhsachDonHang.SingleOrDefault(m => m.Id == IdDonHang);
            return View(Chitiet);
        }
        public ActionResult ThemChiTiet(int IdDonHang)
        {
            ViewBag.IdDonHang = IdDonHang;
            return View(new MayTinh());
        }
        [HttpPost]
        public ActionResult ThemChiTiet(MayTinh model,int IdDonHang)
        {
            // Tim duoc ID Don Hang
            var ChiTiet = DSDonHang.DanhsachDonHang.SingleOrDefault(m => m.Id == IdDonHang);
            ChiTiet.MayTinhDatMua.Add(model);
            return RedirectToAction("Detail", new { IdDonHang = IdDonHang });
        }
        public ActionResult EditDonhang(int IdDonHang, string maMay)
        {
            var Donhang = DSDonHang.DanhsachDonHang.SingleOrDefault(m => m.Id == IdDonHang);
            var mayTinhCanSua = Donhang.MayTinhDatMua.FirstOrDefault(m => m.Mamay == maMay);
            ViewBag.IdDonHang = IdDonHang;

            return View(mayTinhCanSua);
        }
        [HttpPost]
        public ActionResult EditDonhang(MayTinh model,  int IdDonHang)
        {
            var Donhang = DSDonHang.DanhsachDonHang.SingleOrDefault(m => m.Id == IdDonHang);
            var DonHangMoi = Donhang.MayTinhDatMua.FirstOrDefault(m => m.Mamay == model.Mamay);
            DonHangMoi.Price = model.Price;
            DonHangMoi.NSX = model.NSX;
            DonHangMoi.HangSX = model.HangSX;
            DonHangMoi.Tendongmay = model.Tendongmay;
            return RedirectToAction("Detail", new { IdDonHang = IdDonHang });

        }
        public ActionResult DeleteDonHang(int IdDonHang, string maMay)
        {
            var DonHang = DSDonHang.DanhsachDonHang.SingleOrDefault(m => m.Id == IdDonHang);
            var XoaDonHang = DonHang.MayTinhDatMua.SingleOrDefault(m => m.Mamay == maMay);
            DonHang.MayTinhDatMua.Remove(XoaDonHang);
            return RedirectToAction("Detail", new { IdDonHang = IdDonHang });

        }
    }
}
