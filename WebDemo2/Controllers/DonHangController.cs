using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDemo2.Models;

namespace WebDemo2.Controllers
{

    public class DonHangController : Controller
    {

        // GET: KhachHang
        public ActionResult DanhSach()
        {
            BanHangEntities db = new BanHangEntities();

            List<BangMayTinh> DsMayTinh = db.BangMayTinhs.ToList();

            return View(DsMayTinh);
        }
        //Tạo view
        public ActionResult Create()
        {
            return View();
        }
        //Lưu dữ liệu
        [HttpPost]
        public ActionResult Create(BangMayTinh model)
        {
            BanHangEntities db = new BanHangEntities();
            db.BangMayTinhs.Add(model);
            db.SaveChanges();

            return RedirectToAction("DanhSach");
        }
        //Tạo view
        public ActionResult Edit(int ID)
        {
            BanHangEntities db = new BanHangEntities();
            //Tìm ID cần sửa
            var IdCanSua = db.BangMayTinhs.Find(ID);
            // trả về đối tượng cần sửa
            return View(IdCanSua);

        }
        //Lưu dữ liệu
        [HttpPost]
        public ActionResult Edit(BangMayTinh model)
        {
            BanHangEntities db = new BanHangEntities();
            var IdCanSua = db.BangMayTinhs.Find(model.ID);
            IdCanSua.TenMayTinh = model.TenMayTinh;
            IdCanSua.HangSangXuat = model.HangSangXuat;
            IdCanSua.NamSX = model.NamSX;
            db.SaveChanges();
            return RedirectToAction("DanhSach");
        }
        
        public ActionResult Delete(int ID)
        {
            //Tìm ra ID
            BanHangEntities db = new BanHangEntities();
            var IdCanSua = db.BangMayTinhs.Find(ID);
            // Xóa đối tượng được tìm thấy
            db.BangMayTinhs.Remove(IdCanSua);
            db.SaveChanges();
            return RedirectToAction("DanhSach");

        }



    }
}