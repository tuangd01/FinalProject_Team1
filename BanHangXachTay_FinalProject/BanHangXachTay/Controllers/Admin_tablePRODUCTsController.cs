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
    public class Admin_tablePRODUCTsController : Controller
    {
        private CsK23T2aEntities1 db = new CsK23T2aEntities1();

        // GET: Admin_tablePRODUCTs
        public ActionResult Index()
        {
            return View(db.tablePRODUCTs.ToList());
        }

        // GET: Admin_tablePRODUCTs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tablePRODUCT tablePRODUCT = db.tablePRODUCTs.Find(id);
            if (tablePRODUCT == null)
            {
                return HttpNotFound();
            }
            return View(tablePRODUCT);
        }

        // GET: Admin_tablePRODUCTs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin_tablePRODUCTs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idSP,loaiSP,tenSP,dongiaSP,soluongSP,ngaynhap,nhacungcap,img,ghichuSP")] tablePRODUCT tablePRODUCT)
        {
            if (ModelState.IsValid)
            {
                db.tablePRODUCTs.Add(tablePRODUCT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tablePRODUCT);
        }

        // GET: Admin_tablePRODUCTs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tablePRODUCT tablePRODUCT = db.tablePRODUCTs.Find(id);
            if (tablePRODUCT == null)
            {
                return HttpNotFound();
            }
            return View(tablePRODUCT);
        }

        // POST: Admin_tablePRODUCTs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idSP,loaiSP,tenSP,dongiaSP,soluongSP,ngaynhap,nhacungcap,img,ghichuSP")] tablePRODUCT tablePRODUCT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tablePRODUCT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tablePRODUCT);
        }

        // GET: Admin_tablePRODUCTs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tablePRODUCT tablePRODUCT = db.tablePRODUCTs.Find(id);
            if (tablePRODUCT == null)
            {
                return HttpNotFound();
            }
            return View(tablePRODUCT);
        }

        // POST: Admin_tablePRODUCTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tablePRODUCT tablePRODUCT = db.tablePRODUCTs.Find(id);
            db.tablePRODUCTs.Remove(tablePRODUCT);
            db.SaveChanges();
            return RedirectToAction("Index");
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
