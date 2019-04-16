using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BanHangXachTay.Controllers
{
    public class DatHangController : Controller
    {
        //
        // GET: /DatHang/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /DatHang/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /DatHang/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /DatHang/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /DatHang/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /DatHang/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /DatHang/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /DatHang/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
