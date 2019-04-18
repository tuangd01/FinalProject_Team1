using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BanHangXachTay.Controllers
{
    public class ContactController : Controller
    {
        //
        // GET: /Contact/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Admin()
        {
            return View();
        }
	}
}