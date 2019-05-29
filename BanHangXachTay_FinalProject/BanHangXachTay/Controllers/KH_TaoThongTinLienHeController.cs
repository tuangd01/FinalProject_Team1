using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BanHangXachTay.Models;

namespace BanHangXachTay.Controllers
{
    public class KH_TaoThongTinLienHeController : Controller
    {
        private CsK23T2aEntities1 db = new CsK23T2aEntities1();

        // GET: KH_TaoThongTinLienHe
        public ActionResult Index()
        {
            return View(db.Contacts.ToList());
        }

        // GET: KH_TaoThongTinLienHe/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KH_TaoThongTinLienHe/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Contact model)
        {

            model.thoiGianGui = DateTime.Now.Date;
            if (ModelState.IsValid)
            {
                db.Contacts.Add(model);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(model);
        }





        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
