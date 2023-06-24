using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDemo2.Models;

namespace WebDemo2.Controllers
{
    public class KhachHangController : Controller
    {
        // GET: DonHang
        public ActionResult Danhsach()
        {
            // 1: Lấy dữ liệu
            BanHangEntities db = new BanHangEntities();
            List<KhachHang> DSKhachHang = db.KhachHangs.ToList();
            return View(DSKhachHang);
        }
        public ActionResult Themmoi()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Themmoi(KhachHang model)
        {
            // Khai báo db 
            BanHangEntities db = new BanHangEntities();
            if (string.IsNullOrEmpty(model.TenKhachHang))
            {
                ModelState.AddModelError("ID", "Bạn đã nhập thiếu");
                ModelState.AddModelError("TenKhachHang", "Bạn đã nhập thiếu");
                ModelState.AddModelError("SoDienThoai", "Bạn đã nhập thiếu");
                ModelState.AddModelError("DiaChi", "Bạn đã nhập thiếu");
                return View(model);
            }
            db.KhachHangs.Add(model);
            //Lưu lại
            db.SaveChanges();
            return RedirectToAction("Danhsach");
        }
        public ActionResult Edit(int IDkhachhang)
        {
            BanHangEntities db = new BanHangEntities();
            // Tìm đối tượng theo ID
            // Cách 1
            //KhachHang model1 = db.KhachHangs.SingleOrDefault(m => m.ID == IDkhachhang);
            // Cách 2
            KhachHang model2 = db.KhachHangs.Find(IDkhachhang);
            return View(model2);
        }
        //http post dùng để lưu dữ liệu
        [HttpPost]
        public ActionResult Edit(KhachHang model)
        {
            BanHangEntities db = new BanHangEntities();
            var khachhangmoi = db.KhachHangs.Find(model.ID);

            if (string.IsNullOrEmpty(model.TenKhachHang))
            {
                ModelState.AddModelError("TenKhachHang", "Bạn đã nhập thiếu");
                return View(model);
            }
            khachhangmoi.TenKhachHang = model.TenKhachHang;
            khachhangmoi.SoDienThoai = model.SoDienThoai;
            khachhangmoi.DiaChi = model.DiaChi;
            khachhangmoi.IdLoaiKhachHang = model.IdLoaiKhachHang;
            db.SaveChanges();
            return RedirectToAction("Danhsach");

        }
        public ActionResult Delete(int IDkhachhang)
        {
            BanHangEntities db = new BanHangEntities();
            var KHcanxoa = db.KhachHangs.Find(IDkhachhang);
            db.KhachHangs.Remove(KHcanxoa);
            db.SaveChanges();
            return RedirectToAction("Danhsach");

        }
        public ActionResult XoaNhomKH(int IDNhomKH)
        {
            BanHangEntities db = new BanHangEntities();
            // Tìm đối tượng cần xóa
            var NhomKH = db.PhanLoaiKHs.Find(IDNhomKH);
            db.PhanLoaiKHs.Remove(NhomKH);
            db.SaveChanges();
            //Tìm bảng con
            var dsKH = db.KhachHangs.Where(m => m.IdLoaiKhachHang == IDNhomKH).ToList();
            //Xóa bảng con: =>> Phân loại khách hàng là bảng cha của Khách Hàng (IdLoaiKhachHang)
            db.KhachHangs.RemoveRange(dsKH);
            db.SaveChanges();
            return RedirectToAction("Danhsach");
            //Xóa phần tử trong bảng
            foreach(var khachhang in dsKH)
            {
                if (khachhang.TenKhachHang == "Teo")
                {
                    db.KhachHangs.Remove(khachhang);
                }
            }
            //Toi la Tan
            db.SaveChanges();
        }




    }
}