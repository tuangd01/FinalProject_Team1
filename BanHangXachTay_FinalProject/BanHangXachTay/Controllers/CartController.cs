using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BanHangXachTay.Models;

namespace BanHangXachTay.Controllers
{
    public class CartController : Controller
    {
        CsK23T2aEntities1 db = new CsK23T2aEntities1();
        public ActionResult Index()
        {
            var model = Session["Cart"] as List<Cart>;
            if (model == null)
                model = new List<Cart>();
            return View(model);
        }

        static int ID = 0;

        public ActionResult Create(int id)
        {
            var tablePRODUCTofYourCart = db.tablePRODUCTofYourCarts.Find(id);
            if (tablePRODUCTofYourCart == null)
                return HttpNotFound();

            var list = Session["Cart"] as List<Cart>;
            if (list == null)
                list = new List<Cart>();

            var cart = new Cart
            {
                id = ID++,
                tablePRODUCTofYourCart = tablePRODUCTofYourCart,
                tongtien = 0
            };

            list.Add(cart);
            Session["Cart"] = list;
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var list = Session["Cart"] as List<Cart>;
            if (list == null)
                list = new List<Cart>();

            var cart = list.First(c => c.id == id);
            list.Remove(cart);
            Session["Cart"] = list;
            return RedirectToAction("Index");
        }

    }
}