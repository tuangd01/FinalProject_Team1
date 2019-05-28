using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BanHangXachTay.Models;
using BanHangXachTay.Controllers;
using System.Data;
using System.Data.Entity;
using System.Net;


namespace BanHangXachTay.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login()
        {
            return View();
        }
        
    //    {
    //        var tendn = collection["username"];
    //        var matkhau = collection["password"];
    //        if (String.IsNullOrEmpty(tendn))
    //        {
    //            ViewData["Loi1"] = "Bạn Phải Nhập Tên Đăng Nhập";

    //        }
    //        else if (String.IsNullOrEmpty(matkhau))
    //        {
    //            ViewData["Loi2"] = "Bạn Phải Nhập Mật Khẩu";
    //        }
    //        else
    //        {
    //            Admin ad = db.Admins.SingleOrDefault(n => n.UserAdmin == tendn && n.PassAdmin == matkhau);
    //            if (ad != null)
    //            {
    //                Session["Taikhoanadmin"] = ad;
    //                return RedirectToAction("Index", "Admin");
    //            }
    //            else
    //            {
    //                ViewBag.ThongBao = "Tên đăng nhập hoặc mật khẩu không đúng";
    //            }
    //            return View();
    //        }
    //    }


    }
}