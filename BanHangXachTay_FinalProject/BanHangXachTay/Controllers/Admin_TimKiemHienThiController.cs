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
    public class Admin_TimKiemHienThiController : Controller
    {
        private CsK23T2aEntities1 db = new CsK23T2aEntities1();

        // GET: M4_Admin_TimKiemHienThi
        public ActionResult Index(string searchString)
        {

            var model = db.Contacts.AsQueryable();
            if (!String.IsNullOrEmpty(searchString))
            {
                var temp = searchString.Trim().Split('!', '@', '#', '$', '%', '^', '&', '*', '(', ')',
                    '?', '+', '-', '/', '=', ',', '.', '\\', '|', '{', '}', '[', ']', '"', '\'', ';', ':', '<', '>', '~', '`', '_');
                foreach (var spl in temp)
                {
                    model = model.Where(s => s.hoTen.Contains(spl));

                }

            }

            return View(model.ToList());
        }

        // GET: M4_Admin_TimKiemHienThi/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
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
