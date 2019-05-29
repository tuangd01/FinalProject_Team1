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
    public class Admin_tablePRODUCTofYourCartsControllerTest
    {
        [TestMethod]
        public void TestIndex()
        {
            var db = new CsK23T2aEntities1();
            var controller = new Admin_tablePRODUCTofYourCartsController();
            var result = controller.Index();
            var view = result as ViewResult;

            Assert.IsNotNull(view);

            var model = view.Model as List<tablePRODUCTofYourCart>;

            Assert.IsNotNull(model);
            Assert.AreEqual(db.tablePRODUCTofYourCarts.Count(), model.Count);
        }

        [TestMethod]
        public void TestCreateGet()
        {
            var controller = new Admin_tablePRODUCTofYourCartsController();
            var result = controller.Create();
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void TestCreatePost()
        {
            var db = new CsK23T2aEntities1();
            var model = new tablePRODUCTofYourCart
            {
                tenSP = "Vay Sieu Nhan",
                ghichu = "1"
            };
            var controller = new Admin_tablePRODUCTofYourCartsController();

            using (var scope = new TransactionScope())
            {



            }
        }



        [TestMethod]
        public void TestEditGet()
        {
            var db = new CsK23T2aEntities1();
            var item = db.tablePRODUCTofYourCarts.First();
            var controller = new Admin_tablePRODUCTofYourCartsController();
            var result = controller.Edit(0);

            Assert.IsInstanceOfType(result, typeof(HttpNotFoundResult));
        }

        [TestMethod]
        public void TestEditPost()
        {
            var db = new CsK23T2aEntities1();
            var model = new tablePRODUCTofYourCart
            {
                idSP = db.tablePRODUCTofYourCarts.AsNoTracking().First().idSP,
                tenSP = "Vay Sieu Nhan"
            };
            var controller = new Admin_tablePRODUCTofYourCartsController();

            using (var scope = new TransactionScope())
            {
                //var result = controller.Create(model);
                //var view = result as ViewResult;


                //controller = new Admin_tablePRODUCTofYourCartsController();
                //result = controller.Edit(model);

                //var redirect = result as RedirectToRouteResult;

                //Assert.IsNotNull(redirect);
                //Assert.AreEqual("Index", redirect.RouteValues["action"]);

                //var item = db.tablePRODUCTofYourCarts.Find(model.idSP);

                //Assert.IsNotNull(item);
                //Assert.AreEqual(model.tenSP, item.tenSP);

            }
        }

        [TestMethod]
        public void TestDelete()
        {
            var controller = new Admin_tablePRODUCTofYourCartsController();
            var db = new CsK23T2aEntities1();

            using (var scope = new TransactionScope())
            {
                var result = controller.Delete(0);

                Assert.IsInstanceOfType(result, typeof(HttpNotFoundResult));
            }
        }
    }
}
