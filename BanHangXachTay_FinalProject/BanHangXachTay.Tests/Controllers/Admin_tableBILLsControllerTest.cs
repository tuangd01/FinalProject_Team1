using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BanHangXachTay.Models;
using BanHangXachTay.Controllers;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Transactions;

namespace BanHangXachTay.Tests.Controllers
{
    [TestClass]
    public class Admin_tableBILLsControllerTest
    {
        private string searchString;

        [TestMethod]
        public void TestIndex()
        {
            var db = new CsK23T2aEntities1();
            var controller = new Admin_tableBILLsController();
            var result = controller.Index(searchString);
            var view = result as ViewResult;

            Assert.IsNotNull(view);

            var model = view.Model as List<tableBILL>;
            var movies = from m in db.tableBILLs
                         select m;

            Assert.IsNotNull(movies);
            Assert.AreEqual(model, searchString);
        }

        [TestMethod]
        public void TestCreateGet()
        {
            var controller = new Admin_tableBILLsController();
            var result = controller.Create();
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void TestCreatePost()
        {
            var db = new CsK23T2aEntities1();
            var model = new tableBILL
            {
                tenKH = "Nguyen",
                sodienthoaiKH = "0979320779",
                ngaydathang = null,
                ngaynhanhang = null,
                diachinhanhang = "HCM",
                tenSP = "sda",
                dongiaSP = 100,
                soluongSP = 5,
                ghichuSP = "khong",
                thanhtienBILL = 500,
                ghichuBILL = "khong"

            };
            var controller = new Admin_tableBILLsController();

            using (var scope = new TransactionScope())
            {
                var result = controller.Create(model);


                var redirect = result as RedirectToRouteResult;

                Assert.IsNotNull(redirect);
                Assert.AreEqual("Index", redirect.RouteValues["action"]);

                var item = db.tableBILLs.Find(model.idHD);

                Assert.IsNotNull(item);
                Assert.AreEqual(model.tenKH, item.tenKH);
                Assert.AreEqual(model.sodienthoaiKH, item.sodienthoaiKH);
                Assert.AreEqual(model.ngaydathang, item.ngaydathang);
                Assert.AreEqual(model.ngaynhanhang, item.ngaynhanhang);
                Assert.AreEqual(model.diachinhanhang, item.diachinhanhang);
                Assert.AreEqual(model.tenSP, item.tenSP);
                Assert.AreEqual(model.dongiaSP, item.dongiaSP);
                Assert.AreEqual(model.soluongSP, item.soluongSP);
                Assert.AreEqual(model.ghichuSP, item.ghichuSP);
                Assert.AreEqual(model.thanhtienBILL, item.thanhtienBILL);
                Assert.AreEqual(model.ghichuBILL, item.ghichuBILL);
            }
        }

        [TestMethod]
        public void TestEditGet()
        {
            var db = new CsK23T2aEntities1();
            var item = db.tableBILLs.First();
            var controller = new Admin_tableBILLsController();
            var result = controller.Edit(0);

            Assert.IsInstanceOfType(result, typeof(HttpNotFoundResult));

            result = controller.Edit(item.idHD);
            var view = result as ViewResult;

            Assert.IsNotNull(view);

            var model = view.Model as tableBILL;

            Assert.IsNotNull(model);

        }

        [TestMethod]
        public void TestEditPost()
        {
            var db = new CsK23T2aEntities1();
            var model = new tableBILL
            {
                idHD = db.tableBILLs.AsNoTracking().First().idHD,
                tenKH = "Nguyen",
                tenSP = "Vay Sieu Nhan"
            };
            var controller = new Admin_tableBILLsController();

            using (var scope = new TransactionScope())
            {
                var result = controller.Create(model);
                var view = result as ViewResult;


                controller = new Admin_tableBILLsController();
                result = controller.Edit(model);

                var redirect = result as RedirectToRouteResult;

                Assert.IsNotNull(redirect);
                Assert.AreEqual("Index", redirect.RouteValues["action"]);

                var item = db.tableBILLs.Find(model.idHD);

                Assert.IsNotNull(item);
                Assert.AreEqual(model.tenKH, item.tenKH);
                Assert.AreEqual(model.tenSP, item.tenSP);

            }
        }

        [TestMethod]
        public void TestDelete()
        {
            var controller = new Admin_tableBILLsController();
            var db = new CsK23T2aEntities1();

            using (var scope = new TransactionScope())
            {
                var result = controller.Delete(0);

                Assert.IsInstanceOfType(result, typeof(HttpNotFoundResult));
            }
        }
    }
}
