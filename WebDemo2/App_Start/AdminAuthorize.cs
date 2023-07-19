using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebDemo2.Models;

namespace WebDemo2.App_Start
{
    public class AdminAuthorize: AuthorizeAttribute
    {
        public int IdChucNang { get; set; } 
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //B1: Check Session :Đã đăng nhập đúng tk mk chưa => Đã đăng nhập => Cho thực hiện filterContext  
            // Nếu đăng nhập sai trở lại trang đăng nhập
            NhanVien nv = (NhanVien)HttpContext.Current.Session["user"];
            if (nv != null)
            {
                #region CHECK QUYEN
                //B2: Check quyền : Xem tk được sử dụng những quyền nào
                // Nếu không được truy cập vào quyền đó thì báo lỗi không được truy cập
                BanHangEntities db = new BanHangEntities();
                var count = db.PhanQuyens.Count(m => m.IDNhanVien == nv.ID & m.IDChucNang == IdChucNang);
                if (count != 0)
                {
                    // bao khong co quyen
                    return;
                }
                else
                {
                    var returnUrl = filterContext.RequestContext.HttpContext.Request.RawUrl;

                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(
                        new
                        {
                            controller = "BaoLoi",
                            action = "KhongCoQuyen",
                            area = "Admin",
                            returnUrl = returnUrl.ToString()
                        }));
                }
                #endregion

                return;
            }
            else
            {
                var returnUrl = filterContext.RequestContext.HttpContext.Request.RawUrl;

                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(
                    new
                    {
                        controller = "HomeAdmin",
                        action = "Login",
                        area = "Admin",
                        returnUrl = returnUrl.ToString()
                    })) ;
            }
        }
    }
}