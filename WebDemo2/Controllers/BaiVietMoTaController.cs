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
        public ActionResult Index()
        {
            BanHangEntities db = new BanHangEntities();
            List<BaiVietMoTa> dsBaiViet = db.BaiVietMoTas.ToList();
            return View(dsBaiViet);
        }
        public ActionResult Themmoi()
        {
            BanHangEntities db = new BanHangEntities();
            return View();
        }
        [HttpPost]
        public ActionResult Themmoi(BaiVietMoTa model, HttpPostedFileBase fileImg)
        {
            BanHangEntities db = new BanHangEntities();
            if (fileImg.ContentLength > 0)
            {
                // Luu files
                string rootFolder = Server.MapPath("/Data/");
                string pathImage = rootFolder + fileImg.FileName;
                fileImg.SaveAs(pathImage);
                // luu thuoc tinh URL IMG
                model.HinhAnh = "/Data/" + fileImg.FileName;
            }
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
        public ActionResult Edit(BaiVietMoTa model, HttpPostedFileBase fileImg)
        {
            // Tìm ID trong db BaiVietMoTa => BaiVietMoi = ID minh chon trong BaiVietMoTa
            BanHangEntities db = new BanHangEntities();
            if (fileImg.ContentLength > 0)
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

    }
}