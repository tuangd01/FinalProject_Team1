using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BanHangXachTay;

namespace BanHangXachTay.Controllers
{
    public class QLSPController : Controller
    {
        private BanHangEntities db = new BanHangEntities();

        // GET: /QLSP/
        public ActionResult Index(string searchString)
        {
            var sps = from l in db.tableTTSPs
                      select l;
            if (!String.IsNullOrEmpty(searchString))
            {
                sps = sps.Where(s => s.tenSP.Contains(searchString));
            }
            return View(sps);
        }

        // GET: /QLSP/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tableTTSP tablettsp = db.tableTTSPs.Find(id);
            if (tablettsp == null)
            {
                return HttpNotFound();
            }
            return View(tablettsp);
        }

        // GET: /QLSP/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /QLSP/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="idSP,maSP,tenSP,dongia,soluong,ngaynhap,ghichu")] tableTTSP tablettsp)
        {
            if (ModelState.IsValid)
            {
                db.tableTTSPs.Add(tablettsp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tablettsp);
        }

        // GET: /QLSP/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tableTTSP tablettsp = db.tableTTSPs.Find(id);
            if (tablettsp == null)
            {
                return HttpNotFound();
            }
            return View(tablettsp);
        }

        // POST: /QLSP/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="idSP,maSP,tenSP,dongia,soluong,ngaynhap,ghichu")] tableTTSP tablettsp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tablettsp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tablettsp);
        }

        // GET: /QLSP/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tableTTSP tablettsp = db.tableTTSPs.Find(id);
            if (tablettsp == null)
            {
                return HttpNotFound();
            }
            return View(tablettsp);
        }

        // POST: /QLSP/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tableTTSP tablettsp = db.tableTTSPs.Find(id);
            db.tableTTSPs.Remove(tablettsp);
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
