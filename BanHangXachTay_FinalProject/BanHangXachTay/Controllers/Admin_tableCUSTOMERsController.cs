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
    public class Admin_tableCUSTOMERsController : Controller
    {
        private CsK23T2aEntities1 db = new CsK23T2aEntities1();

        // GET: Admin_tableCUSTOMERs
        public ActionResult Index()
        {
            var model = db.tableCUSTOMERs.ToList();
            ViewBag.Message = TempData["StatusMessage"];
            return View(model);
        }

        // GET: Admin_tableCUSTOMERs/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = db.tableCUSTOMERs.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // GET: Admin_tableCUSTOMERs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin_tableCUSTOMERs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( tableCUSTOMER model)
        {
            if (ModelState.IsValid)
            {
                db.tableCUSTOMERs.Add(model);
                db.SaveChanges();
                TempData["StatusMessage"] = "Create successfully";
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Admin_tableCUSTOMERs/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = db.tableCUSTOMERs.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Admin_tableCUSTOMERs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tableCUSTOMER model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                TempData["StatusMessage"] = "Edit successfully";
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Admin_tableCUSTOMERs/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = db.tableCUSTOMERs.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Admin_tableCUSTOMERs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var model = db.tableCUSTOMERs.Find(id);
            db.tableCUSTOMERs.Remove(model);
            db.SaveChanges();
            TempData["StatusMessage"] = "Delete successfully";
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
