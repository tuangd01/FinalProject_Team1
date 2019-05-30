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
    public class Admin_tableCUSTOMERsControllerTest
    {
        private string searchString;

        [TestMethod]
        public void TestIndex()
        {
            var db = new CsK23T2aEntities1();
            var controller = new Admin_tableCUSTOMERsController();
            var result = controller.Index(searchString);
            var view = result as ViewResult;

            Assert.IsNotNull(view);

            var model = view.Model as List<tableCUSTOMER>;
            var movies = from m in db.tableCUSTOMERs
                         select m;

            Assert.IsNotNull(movies);
            Assert.AreEqual(model, searchString);
        }

        [TestMethod]
        public void TestCreateGet()
        {
            var controller = new Admin_tableCUSTOMERsController();
            var result = controller.Create();
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void TestCreatePost()
        {
            var db = new CsK23T2aEntities1();
            var model = new tableCUSTOMER
            {
                tenKH = "Nguyen",
                gioitinh = "Nam",
                sodienthoaiKH = "0979320779",
                diachi = "HCM",
                ghichu = "1"
            };
            var controller = new Admin_tableCUSTOMERsController();

            using (var scope = new TransactionScope())
            {
                var result = controller.Create(model);


                var redirect = result as RedirectToRouteResult;

                Assert.IsNotNull(redirect);
                Assert.AreEqual("Index", redirect.RouteValues["action"]);

                var item = db.tableCUSTOMERs.Find(model.idKH);

                Assert.IsNotNull(item);
                Assert.AreEqual(model.tenKH, item.tenKH);
                Assert.AreEqual(model.gioitinh, item.gioitinh);
                Assert.AreEqual(model.sodienthoaiKH, item.sodienthoaiKH);
                Assert.AreEqual(model.diachi, item.diachi);
                Assert.AreEqual(model.ghichu, item.ghichu);

            }
        }


        [TestMethod]
        public void TestEditGet()
        {
            var db = new CsK23T2aEntities1();
            var item = db.tableCUSTOMERs.First();
            var controller = new Admin_tableCUSTOMERsController();
            var result = controller.Edit(0);

            Assert.IsInstanceOfType(result, typeof(HttpNotFoundResult));

            result = controller.Edit(item.idKH);
            var view = result as ViewResult;

            Assert.IsNotNull(view);

            var model = view.Model as tableCUSTOMER;

            Assert.IsNotNull(model);

        }

        [TestMethod]
        public void TestEditPost()
        {
            var db = new CsK23T2aEntities1();
            var model = new tableCUSTOMER
            {
                idKH = db.tableCUSTOMERs.AsNoTracking().First().idKH,
                tenKH = "Nguyen123"
            };
            var controller = new Admin_tableCUSTOMERsController();

            using (var scope = new TransactionScope())
            {
                var result = controller.Create(model);
                var view = result as ViewResult;


                controller = new Admin_tableCUSTOMERsController();
                result = controller.Edit(model);

                var redirect = result as RedirectToRouteResult;

                Assert.IsNotNull(redirect);
                Assert.AreEqual("Index", redirect.RouteValues["action"]);

                var item = db.tableCUSTOMERs.Find(model.idKH);

                Assert.IsNotNull(item);
                Assert.AreEqual(model.tenKH, item.tenKH);

            }
        }

        [TestMethod]
        public void TestDelete()
        {
            var controller = new Admin_tableCUSTOMERsController();
            var db = new CsK23T2aEntities1();

            using (var scope = new TransactionScope())
            {
                var result = controller.Delete(0);

                Assert.IsInstanceOfType(result, typeof(HttpNotFoundResult));
            }
        }



    }
}
