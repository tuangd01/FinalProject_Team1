using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BanHangXachTay.Models;
using BanHangXachTay.Controllers;
using System.Collections.Generic;
using System.Transactions;
using System.Linq;
using System.Web.Mvc;

namespace BanHangXachTay.Tests.Controllers
{
    [TestClass]
    public class Admin_CapNhat_Xoa_TraLoiTest

    {
        [TestMethod]
        public void TestXoa()
        {
            var db = new CsK23T2aEntities1();
            var controller = new Admin_CapNhat_Xoa_TraLoiController();
            using (var scope = new TransactionScope())
            {
                var result = controller.Xoa(2);
                Assert.IsInstanceOfType(result, typeof(HttpNotFoundResult));

                var model = db.Contacts.AsNoTracking().First();
                result = controller.Xoa(model.idContact);
                var redirect = result as RedirectToRouteResult;
                Assert.IsNotNull(redirect);
                Assert.AreEqual("Index", redirect.RouteValues["action"]);
                var item = db.Contacts.Find(model.idContact);
                Assert.IsNull(item);
            }
        }

        [TestMethod]
        public void TestTraLoiGet()
        {
            var db = new CsK23T2aEntities1();
            var item = db.Contacts.First();
            var controller = new Admin_CapNhat_Xoa_TraLoiController();
            var result = controller.TraLoi(2);

            Assert.IsInstanceOfType(result, typeof(HttpNotFoundResult));

            result = controller.TraLoi(item.idContact);
            var view = result as ViewResult;
            Assert.IsNotNull(view);
            var model = view.Model as Contact;
            Assert.IsNotNull(model);
            Assert.AreEqual(item.idContact, model.idContact);
            Assert.AreEqual(item.chuDe, model.chuDe);
            Assert.AreEqual(item.tieuDe, model.tieuDe);
            Assert.AreEqual(item.noiDung, model.noiDung);
            Assert.AreEqual(item.hoTen, model.hoTen);
            Assert.AreEqual(item.email, model.email);
            Assert.AreEqual(item.sdt, model.sdt);
            Assert.AreEqual(item.thoiGianGui, model.thoiGianGui);
            Assert.AreEqual(item.traLoi, model.traLoi);
            Assert.AreEqual(item.thoigianTraLoi, model.thoigianTraLoi);
            Assert.AreEqual(item.trangThai, model.trangThai);
            Assert.AreEqual(item.ghiChu, model.ghiChu);
        }

        [TestMethod]
        public void TestTraLoiPost()
        {
            var db = new CsK23T2aEntities1();
            var model = new Contact
            {
                idContact = db.Contacts.AsNoTracking().First().idContact,
                chuDe = "chủ đề",
                tieuDe = "Tiêu đề",
                hoTen = "Họ tên",
                noiDung = "Nội dung",
                email = "Email",
                sdt = "0123456789",


            };
            var controller = new Admin_CapNhat_Xoa_TraLoiController();

            using (var scope = new TransactionScope())
            {
                var result = controller.TraLoi(model);
                var view = result as ViewResult;
                //Assert.IsNotNull(view);
                //Assert.IsInstanceOfType(view.Model, typeof(Contact));

                //model.traLoi = "Trả Lời";
                //model.trangThai = true;
                //model.thoigianTraLoi = DateTime.Now.Date;

                //controller = new Admin_CapNhat_Xoa_TraLoiController();
                //result = controller.TraLoi(model);
                //var redirect = result as RedirectToRouteResult;
                //Assert.IsNotNull(redirect);
                //Assert.AreEqual("Index", redirect.RouteValues["action"]);
                //var item = db.Contacts.Find(model.idContact);
                //Assert.IsNotNull(item);
                //Assert.AreEqual(model.idContact, item.idContact);
                //Assert.AreEqual(model.chuDe, item.chuDe);
                //Assert.AreEqual(model.tieuDe, item.tieuDe);
                //Assert.AreEqual(model.noiDung, item.noiDung);
                //Assert.AreEqual(model.hoTen, item.hoTen);
                //Assert.AreEqual(model.email, item.email);
                //Assert.AreEqual(model.sdt, item.sdt);
                //Assert.AreEqual(model.thoiGianGui, item.thoiGianGui);
                //Assert.AreEqual(model.traLoi, item.traLoi);
                //Assert.AreEqual(model.thoigianTraLoi, item.thoigianTraLoi);
                //Assert.AreEqual(model.trangThai, item.trangThai);
                //Assert.AreEqual(model.ghiChu, item.ghiChu);
            }
        }
    }
}
