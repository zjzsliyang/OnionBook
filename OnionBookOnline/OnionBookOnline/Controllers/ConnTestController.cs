using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnionBookOnline.DAL;
using OnionBookOnline.Models;

namespace OnionBookOnline.Controllers
{
    public class ConnTestController : Controller
    {
        //[AllowAnonymous]
        public ConnTestController() { }

        public ActionResult Index()
        {
            var resList = new List<AUTHOR>();

            using (var context = new OnionContext())
            {
                var query = from a in context.authors
                            select a;
                var res = query.ToList();

                for (int i = 0; i < 5; ++i)
                {
                    resList.Add(res[i]);
                }
            }
            return View(resList);
        }
    }
}