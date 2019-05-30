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
    public class Admin_tablePRODUCTofYourCartsController : Controller
    {
        private CsK23T2aEntities1 db = new CsK23T2aEntities1();

        // GET: Admin_tablePRODUCTofYourCarts
        public ActionResult Index(string searchString)
        {
            var model = db.tablePRODUCTofYourCarts.ToList();
            ViewBag.Message = TempData["StatusMessage"];
            var movies = from m in db.tablePRODUCTofYourCarts
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.tenSP.Contains(searchString));

            }

            return View(movies);
            return View(model);
        }

        // GET: Admin_tablePRODUCTofYourCarts/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = db.tablePRODUCTofYourCarts.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // GET: Admin_tablePRODUCTofYourCarts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin_tablePRODUCTofYourCarts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tablePRODUCTofYourCart model)
        {
            if (ModelState.IsValid)
            {
                using (var scope = new TransactionScope())
                {
                    // add model to database
                    db.tablePRODUCTofYourCarts.Add(model);
                    db.SaveChanges();
                    TempData["StatusMessage"] = "Create successfully";
                    // save file to App_Data
                    var path = Server.MapPath("~/App_Data");
                    path = System.IO.Path.Combine(path, model.idSP.ToString());
                    Request.Files["Image"].SaveAs(path);
                    // accept all and persistence
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

        // GET: Admin_tablePRODUCTofYourCarts/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = db.tablePRODUCTofYourCarts.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Admin_tablePRODUCTofYourCarts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tablePRODUCTofYourCart model)
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

        // GET: Admin_tablePRODUCTofYourCarts/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = db.tablePRODUCTofYourCarts.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Admin_tablePRODUCTofYourCarts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var model = db.tablePRODUCTofYourCarts.Find(id);
            db.tablePRODUCTofYourCarts.Remove(model);
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
