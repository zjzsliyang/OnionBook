using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnionBookOnline.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Search()
        {
            return View();
        }

        public ActionResult Recommend()
        {
            return View();
        }

        public ActionResult New()
        {
            return View();
        }

        public ActionResult Hot()
        {
            return View();
        }
    }
}