using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDemo1.Models;


namespace WebDemo1.Controllers
{
    public class KhachHangController : Controller
    {
        // GET: KhachHang
        public ActionResult DanhSach()
        {
            return View(DSKhachHang.ListKhachHang);
        }
        public ActionResult Themmoi()
        {
            return View(new Khachhang());
           

        }
        [HttpPost]
        public ActionResult Themmoi(Khachhang model, HttpPostedFileBase fileImg)
        {
            //DSKhachHang.ListKhachHang.Add(new Khachhang()
            //{
            //    ID = model.ID,
            //    Name = model.Name,
            //    PhoneNumber = model.PhoneNumber,
            //    Address = model.Address,
            //    Email = model.Email,
            //    Sex = model.Sex

            //});
            //return RedirectToAction("DanhSach");
            if (model.ID == 0)
            {
                ModelState.AddModelError("", "Bạn đã nhập sai hoặc thiếu ID");
                return View(model);
            }
            if (fileImg.ContentLength > 0)
            {
                // Luu file
                string rootFolder = Server.MapPath("/Data/");
                string pathImage = rootFolder + fileImg.FileName;
                fileImg.SaveAs(pathImage);
                // luu thuoc tinh URL IMG
                model.UrlImg = "/Data/" + fileImg.FileName;
            }
            DSKhachHang.ListKhachHang.Add(model);
            return RedirectToAction("DanhSach");


        }
        public ActionResult Edit(int IDKhachhang)
        {
            // Tìm ra ID cần sửa
            var khachhang = DSKhachHang.ListKhachHang.SingleOrDefault(m => m.ID == IDKhachhang);
            // Truyền thông tin đối tượng cần sửa sang view
            return View(khachhang);
        }
        [HttpPost]
        public ActionResult Edit(Khachhang model , HttpPostedFileBase fileImg)
        {

            if (fileImg.ContentLength > 0)
            {
                // Luu file
                string rootFolder = Server.MapPath("/Data/");
                string pathImage = rootFolder + fileImg.FileName;
                fileImg.SaveAs(pathImage);
                // luu thuoc tinh URL IMG
                model.UrlImg = "/Data/" + fileImg.FileName;
            }



            if (string.IsNullOrEmpty(model.Name) == true)
            {
                ModelState.AddModelError("", "Bạn đã nhập sai hoặc thiếu Tên");
                return View(model);
            }
            //ModelState.AddModelError("", string.IsNullOrEmpty(model.Name) ? "Bạn đã nhập sai hoặc thiếu Tên" : "");
            //ModelState.AddModelError("", string.IsNullOrEmpty(model.Address) ? "Bạn đã nhập sai hoặc thiếu Địa Chỉ" : "");
            //ModelState.AddModelError("", string.IsNullOrEmpty(model.Email) ? "Bạn đã nhập sai hoặc thiếu Email" : "");
            //ModelState.AddModelError("", string.IsNullOrEmpty(model.PhoneNumber) ? "Bạn đã nhập sai hoặc thiếu Số Điện Thoại" : "");


            //Tìm ID cần sửa
            var khachhang = DSKhachHang.ListKhachHang.SingleOrDefault(m => m.ID == model.ID);
            //Cập nhật dữ liệu
            khachhang.Name = model.Name;
            khachhang.Address = model.Address;
            khachhang.Email = model.Email;
            khachhang.PhoneNumber = model.PhoneNumber;
            khachhang.Sex = model.Sex;
            khachhang.UrlImg = model.UrlImg;
            return RedirectToAction("DanhSach");
        }
        public ActionResult Delete(int IDKhachHang)
        {
            // Tìm ID cần xóa
            var khachhang = DSKhachHang.ListKhachHang.SingleOrDefault(m => m.ID == IDKhachHang);
            // Xóa ID
            DSKhachHang.ListKhachHang.Remove(khachhang);
            return RedirectToAction("DanhSach");

        }
    }
}
