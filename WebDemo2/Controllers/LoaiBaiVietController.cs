using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDemo2.Models;

namespace WebDemo2.Controllers
{
    public class LoaiBaiVietController : Controller
    {
        // GET: LoaiBaiViet
        public ActionResult DanhSach()
        {
            BanHangEntities db = new BanHangEntities();
            return View(db.LoaiBaiViets.ToList());
        }
        public ActionResult ThemMoi()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemMoi(LoaiBaiViet model)
        {
            BanHangEntities db = new BanHangEntities();
            db.LoaiBaiViets.Add(model);
            db.SaveChanges();
            return RedirectToAction("DanhSach");

        }
        public ActionResult Edit(int ID)
        {
            BanHangEntities db = new BanHangEntities();
            var LoaiBaiVietCanTim = db.LoaiBaiViets.Find(ID);
            return View(LoaiBaiVietCanTim);
        }
        [HttpPost]
        public ActionResult Edit(LoaiBaiViet model)
        {
            BanHangEntities db = new BanHangEntities();
            var BaiVietCanTim = db.LoaiBaiViets.Find(model.ID);
            BaiVietCanTim.TenLoai = model.TenLoai;
            db.SaveChanges();
            return RedirectToAction("DanhSach");
        }
        public ActionResult Delete(int ID)
        {
            BanHangEntities db = new BanHangEntities();
            var BaiVietCanXoa = db.LoaiBaiViets.Find(ID);
            db.LoaiBaiViets.Remove(BaiVietCanXoa);
            db.SaveChanges();
            return RedirectToAction("DanhSach");
        }

    }
}