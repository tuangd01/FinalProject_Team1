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
    public class Admin_CapNhat_Xoa_TraLoiController : Controller
    {
        private CsK23T2aEntities1 db = new CsK23T2aEntities1();



        // GET: /Admin_CapNhat_Xoa_TraLoi/Edit/5
        public ActionResult TraLoi(int? id)
        {
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: /Admin_CapNhat_Xoa_TraLoi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TraLoi(Contact model)
        {
            if (model.traLoi == null) { model.trangThai = false; }
            else { model.trangThai = true; }
            model.thoigianTraLoi = DateTime.Now.Date;

            if (ModelState.IsValid)
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "M4_Admin_TimKiemHienThi");
            }
            return View(model);
        }

        // GET: /Admin_CapNhat_Xoa_TraLoi/Delete/5
        public ActionResult Xoa(int? id)
        {
            
            var model = db.Contacts.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            } db.Contacts.Remove(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: /Admin_CapNhat_Xoa_TraLoi/Delete/5
    

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
