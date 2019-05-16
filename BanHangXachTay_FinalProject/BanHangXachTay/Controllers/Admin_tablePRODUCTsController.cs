using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BanHangXachTay.Models;
using System.Transactions;

namespace BanHangXachTay.Controllers
{
    public class Admin_tablePRODUCTsController : Controller
    {
        private CsK23T2aEntities1 db = new CsK23T2aEntities1();

        // GET: Admin_tablePRODUCTs
        public ActionResult Index()
        {
            var model = db.tablePRODUCTs.ToList();
            return View(model);
        }

        // GET: Admin_tablePRODUCTs/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = db.tablePRODUCTs.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
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
        public ActionResult Create(tablePRODUCT model)
        {
            if (ModelState.IsValid)
            {
                using (var scope = new TransactionScope())
                {
                    //Add Day
                    model.ngaynhap = DateTime.Today;

                    //Add model to database
                    db.tablePRODUCTs.Add(model);
                    db.SaveChanges();

                    //Save file to App_Data
                    var path = Server.MapPath("~/App_Data");
                    path = System.IO.Path.Combine(path, model.idSP.ToString());
                    Request.Files["Image"].SaveAs(path);

                    //Accept all and persistence
                    scope.Complete();
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }

        public ActionResult Image(string id)
        {
            var path = Server.MapPath("~/App_Data");
            path = System.IO.Path.Combine(path, id);
            return File(path, "image/*");
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
