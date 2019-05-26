using BanHangXachTay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BanHangXachTay.Controllers
{
    public class HomeController : Controller
    {
         CsK23T2aEntities1 db = new CsK23T2aEntities1();

        private List<tablePRODUCT> SPMoi(int count)
         {

             return db.tablePRODUCTs.OrderByDescending(a => a.ngaynhap).Take(count).ToList();
           
         }
        public ActionResult Details(int id)
        {
            var sanpham = from s in db.tablePRODUCTs
                          where s.idSP == id
                          select s;
            return View(sanpham.Single());
        }
        public ActionResult Index()
        {
            var domoi = SPMoi(6);
            return View(domoi);
        }

        public ActionResult AboutViews()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult ContactViews()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult YourCartViews()
        {
            ViewBag.Message = "Your cart page.";

            return View();
        }

        public ActionResult WomanViews()
        {
            return View();
        }

        public ActionResult ManViews()
        {
            return View();
        }
    }
}