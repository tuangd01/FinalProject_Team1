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
    public class Admin_tableBILLsController : Controller
    {
        private CsK23T2aEntities1 db = new CsK23T2aEntities1();

        // GET: Admin_tableBILLs
        public ActionResult Index()
        {
            return View(db.tableBILLs.ToList());
        }

        // GET: Admin_tableBILLs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tableBILL tableBILL = db.tableBILLs.Find(id);
            if (tableBILL == null)
            {
                return HttpNotFound();
            }
            return View(tableBILL);
        }

        // GET: Admin_tableBILLs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin_tableBILLs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idHD,idKH,tenKH,sodienthoaiKH,ngaydathang,ngaygiaohang,ngaynhanhang,diachinhanhang,idSP,tenSP,dongiaSP,soluongSP,ghichuSP,thanhtienBILL,soluongBILL,dongiaBILL,tongdoanhthu,ghichuBILL")] tableBILL tableBILL)
        {
            if (ModelState.IsValid)
            {
                db.tableBILLs.Add(tableBILL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tableBILL);
        }

        // GET: Admin_tableBILLs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tableBILL tableBILL = db.tableBILLs.Find(id);
            if (tableBILL == null)
            {
                return HttpNotFound();
            }
            return View(tableBILL);
        }

        // POST: Admin_tableBILLs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idHD,idKH,tenKH,sodienthoaiKH,ngaydathang,ngaygiaohang,ngaynhanhang,diachinhanhang,idSP,tenSP,dongiaSP,soluongSP,ghichuSP,thanhtienBILL,soluongBILL,dongiaBILL,tongdoanhthu,ghichuBILL")] tableBILL tableBILL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tableBILL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tableBILL);
        }

        // GET: Admin_tableBILLs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tableBILL tableBILL = db.tableBILLs.Find(id);
            if (tableBILL == null)
            {
                return HttpNotFound();
            }
            return View(tableBILL);
        }

        // POST: Admin_tableBILLs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tableBILL tableBILL = db.tableBILLs.Find(id);
            db.tableBILLs.Remove(tableBILL);
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
