using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDemo2.Models;

namespace WebDemo2.Controllers
{
    public class BaiVietMoTaController : Controller
    {
        // GET: BaiVietMoTa
        public ActionResult Index(string find, int? idBaiVietnew)
        {
            BanHangEntities db = new BanHangEntities();
            //List<BaiVietMoTa> dsBaiViet = db.BaiVietMoTas.Where
            //    (m => m.TenBaiViet.ToLower().Contains(find) == true
            //    || m.NguoiViet.ToLower().Contains(find)).ToList();

            //List<BaiVietMoTa> dsBaiViet = (from m in db.BaiVietMoTas
            //                               join n in db.LoaiBaiViets on m.idBaiViet equals n.ID
            //                               where (string.IsNullOrEmpty(find) ||
            //                               m.TenBaiViet.ToLower().Contains(find.ToLower()) == true
            //                               || m.NguoiViet.ToLower().Contains(find.ToLower()) == true)
            //                               & (n.ID == idBaiVietnew | idBaiVietnew == null)
            //                               select m).ToList();
            List<spDanhSachBaiViet_Result> dsBaiViet= db.spDanhSachBaiViet(find,idBaiVietnew).ToList();
            ViewBag.find = find;
            ViewBag.idBaiVietnew = idBaiVietnew;
            return View(dsBaiViet);
        }
        public ActionResult Themmoi()
        {
            BanHangEntities db = new BanHangEntities();
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]

        public ActionResult Themmoi(BaiVietMoTa model, HttpPostedFileBase fileImg)
        {
            BanHangEntities db = new BanHangEntities();
            if (fileImg != null && fileImg.FileName != null)
            {
                // Luu files
                string rootFolder = Server.MapPath("/Data/");
                string pathImage = rootFolder + fileImg.FileName;
                fileImg.SaveAs(pathImage);
                // luu thuoc tinh URL IMG
                model.HinhAnh = "/Data/" + fileImg.FileName;
            }
            model.HinhAnh = "/Data/" + fileImg.FileName;
            db.BaiVietMoTas.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int ID)
        {
            BanHangEntities db = new BanHangEntities();
            BaiVietMoTa model = db.BaiVietMoTas.Find(ID);
            return View(model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(BaiVietMoTa model, HttpPostedFileBase fileImg)
        {
            // Tìm ID trong db BaiVietMoTa => BaiVietMoi = ID minh chon trong BaiVietMoTa
            BanHangEntities db = new BanHangEntities();
            if (fileImg != null && fileImg.FileName != null)
            {
                // Luu files
                string rootFolder = Server.MapPath("/Data/");
                string pathImage = rootFolder + fileImg.FileName;
                fileImg.SaveAs(pathImage);
                // luu thuoc tinh URL IMG
                model.HinhAnh = "/Data/" + fileImg.FileName;
            }

            var BaiVietMoi = db.BaiVietMoTas.Find(model.ID);
            BaiVietMoi.TenBaiViet = model.TenBaiViet;
            BaiVietMoi.MoTa = model.MoTa;
            BaiVietMoi.NgayViet = model.NgayViet;
            BaiVietMoi.NguoiViet = model.NguoiViet;
            BaiVietMoi.NoiDung = model.NoiDung;
            BaiVietMoi.HinhAnh = model.HinhAnh;
            BaiVietMoi.IsHienThi = model.IsHienThi;
            BaiVietMoi.ThuTu = model.ThuTu;
            BaiVietMoi.idBaiViet = model.idBaiViet;

            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int ID)
        {
            BanHangEntities db = new BanHangEntities();
            var BaiVietCanXoa = db.BaiVietMoTas.Find(ID);
            db.BaiVietMoTas.Remove(BaiVietCanXoa);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        // Các bước nhúng CKEditor
        // Tải bộ plugin và cho vào project
        // Kéo file JS vào Layout
        // Thay đổi input thành nội dung thành textarea , có đặt ID cho Input
        // Viết lệnh Js cho input
        // Lưu dữ liệu  - Tắt kiểm tra HTML cho Action lưu dữ liệu         [ValidateInput(false)]



        //Sử Dụng CKFinder
        // Tải bộ plugin và cho vào project
        // Kéo file JS vào Layout
        // Cấu hình CKFinder
    }
}