using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnionBookOnline.Models;

namespace OnionBookOnline.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.count = "1";
            ViewBag.prize = "244元";
            ViewBag.item = new string[] { "假装是一本书", "数量：1", "244元" };

            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}