using System;
using System.Web.Mvc;
using BanHangXachTay.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BanHangXachTay.Tests.Controllers
{
    [TestClass]
    public class YourCartControllerTest
    {
        [TestMethod]
        public void TestIndex()
        {
            var controller = new YourCartController();

            var result = controller.YourCartViews() as ViewResult;

            Assert.IsNotNull(result);

        }
    }
}
