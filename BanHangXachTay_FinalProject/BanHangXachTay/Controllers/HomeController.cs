﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BanHangXachTay.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AboutViews()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult ContactViews()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult YourCartViews()
        {
            ViewBag.Message = "Your cart page.";

            return View();
        }

        public ActionResult WomanViews()
        {
            return View();
        }

        public ActionResult ManViews()
        {
            return View();
        }
    }
}