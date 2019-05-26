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
using System.Linq.Expressions;
using PagedList;
using PagedList.Mvc;


namespace BanHangXachTay.Controllers
{
    public class Admin_tablePRODUCTsController : Controller
    {
        private CsK23T2aEntities1 db = new CsK23T2aEntities1();

        // GET: Admin_tablePRODUCTs
        public ActionResult Index(int? size, int? page, string sortProperty, string sortOrder, string searchString)
        {
            // 1. Tạo biến ViewBag gồm sortOrder, searchValue, sortProperty và page
            if (sortOrder == "asc") ViewBag.sortOrder = "desc";
            if (sortOrder == "desc") ViewBag.sortOrder = "";
            if (sortOrder == "") ViewBag.sortOrder = "asc";
            ViewBag.searchValue = searchString;
            ViewBag.sortProperty = sortProperty;
            ViewBag.page = page;

            // 2. Tạo danh sách chọn số trang
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "5 Sản Phẩm", Value = "5" });
            items.Add(new SelectListItem { Text = "7 Sản Phẩm", Value = "7" });
            items.Add(new SelectListItem { Text = "10 Sản Phẩm", Value = "10" });
            items.Add(new SelectListItem { Text = "15 Sản Phẩm", Value = "15" });
            items.Add(new SelectListItem { Text = "30 Sản Phẩm", Value = "30" });
            items.Add(new SelectListItem { Text = "100 Sản Phẩm", Value = "100" });
            items.Add(new SelectListItem { Text = "200 Sản Phẩm", Value = "200" });

            // 3. Thiết lập số trang đang chọn vào danh sách List<SelectListItem> items
            foreach (var item in items)
            {
                if (item.Value == size.ToString()) item.Selected = true;
            }
            ViewBag.size = items;
            ViewBag.currentSize = size;


            // 4. Truy vấn lấy tất cả đường dẫn
            var sanpham = from l in db.tablePRODUCTs
                          select l;

            // 5. Tạo thuộc tính sắp xếp mặc định là "ID"
            if (String.IsNullOrEmpty(sortProperty)) sortProperty = "ID";

            // 5. Thêm phần tìm kiếm
            if (!String.IsNullOrEmpty(searchString))
            {
                sanpham = sanpham.Where(s => s.tenSP.Contains(searchString));
            }


            // Tạo kích thước trang (pageSize), mặc định là 5.
            page = page ?? 1;
            int pageSize = (size ?? 5);

            ViewBag.pageSize = pageSize;

            // 6. Toán tử ?? trong C# mô tả nếu page khác null thì lấy giá trị page, còn
            // nếu page = null thì lấy giá trị 1 cho biến pageNumber. 
            int pageNumber = (page ?? 1);

            // 6.2 Lấy tổng số record chia cho kích thước để biết bao nhiêu trang
            int checkTotal = (int)(sanpham.ToList().Count / pageSize) + 1;
            // Nếu trang vượt qua tổng số trang thì thiết lập là 1 hoặc tổng số trang
            if (pageNumber > checkTotal) pageNumber = checkTotal;

            // 7. Trả về các Sản phẩm được phân trang theo kích thước và số trang.
            return View(db.tablePRODUCTs.ToList().OrderBy(n => n.idSP).ToPagedList(pageNumber, pageSize));

            /// aaaaaaaaaa
        }
        [HttpPost]

        public ActionResult Reset()
        {
            ViewBag.searchValue = "";
            Index(null, null, "", "", "");
            return View();
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
            ViewBag.idloaiSP = new SelectList(db.LoaiSanPhams.ToList().OrderBy(n => n.TenLoaiSP), "idloaiSP", "TenLoaiSP");
            ViewBag.MaNCC = new SelectList(db.NHACUNGCAPs.ToList().OrderBy(n => n.TenNCC), "MaNCC","TenNCC");
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
        public ActionResult Edit(int id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tablePRODUCT tablePRODUCT = db.tablePRODUCTs.Find(id);
            if (tablePRODUCT == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.idloaiSP = new SelectList(db.LoaiSanPhams.ToList().OrderBy(n => n.TenLoaiSP), "idLSP", "TenLoaiSP", tablePRODUCT.idloaiSP);
            ViewBag.MaNCC = new SelectList(db.NHACUNGCAPs.ToList().OrderBy(n => n.TenNCC), "MaNCC", "TenNCC", tablePRODUCT.MaNCC);
            return View(tablePRODUCT);

            
        }


        // POST: Admin_tablePRODUCTs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tablePRODUCT model)
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

       


    }
}
