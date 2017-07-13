using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnionBookOnline.DAL;
using OnionBookOnline.Models;

namespace OnionBookOnline.Controllers
{
    public class HomeController : Controller
    {
        private IEnumerable<HomeBookInfo> queryOnSales(OnionContext context, string primaryid)
        {
            IEnumerable<HomeBookInfo> qsp = from b in context.books
                                            join c in context.pictures on b.BOOKID equals c.BOOKID
                                            join d in context.writes on b.BOOKID equals d.BOOKID
                                            join e in context.authors on d.AUTHORID equals e.AUTHORID
                                            where b.PRIMARYID == primaryid
                                            orderby b.DISCOUNT ascending
                                            select new HomeBookInfo()
                                            {
                                                NAME = b.NAME,
                                                AUTHORNAME = e.NAME,
                                                SCORE = b.SCORE,
                                                PRICE = b.PRICE,
                                                DISCOUNT = b.DISCOUNT,
                                                PATH = c.PATH
                                            };
            return qsp;
        }
        public ActionResult Index()
        {
            var HomeVM = new HomeIndexViewModel();
            HomeVM.bpsLit = new List<HomeBookInfo>();
            HomeVM.bpsPop = new List<HomeBookInfo>();
            HomeVM.bpsCul = new List<HomeBookInfo>();
            HomeVM.bpsLif = new List<HomeBookInfo>();
            HomeVM.bpsEco = new List<HomeBookInfo>();
            HomeVM.bpsTec = new List<HomeBookInfo>();
            HomeVM.bpsRank = new List<HomeBookInfo>();
            HomeVM.bpsScore = new List<HomeBookInfo>();
            HomeVM.bpsLatest = new List<HomeBookInfo>();

            using (var context = new OnionContext())
            {

                //On sales
                var queryLit = queryOnSales(context, "01");
                var queryPop = queryOnSales(context, "02");
                var queryCul = queryOnSales(context, "03");
                var queryLif = queryOnSales(context, "04");
                var queryEco = queryOnSales(context, "05");
                var queryTec = queryOnSales(context, "06");

                var resLit = queryLit.ToList();
                var resPop = queryPop.ToList();
                var resCul = queryCul.ToList();
                var resLif = queryLif.ToList();
                var resEco = queryEco.ToList();
                var resTec = queryTec.ToList();


                //best seller
                var queryRank = from b in context.books
                                join c in context.pictures on b.BOOKID equals c.BOOKID
                                join d in context.writes on b.BOOKID equals d.BOOKID
                                join e in context.authors on d.AUTHORID equals e.AUTHORID
                                orderby b.SALE descending
                                select new HomeBookInfo()
                                {
                                    NAME = b.NAME,
                                    AUTHORNAME = e.NAME,
                                    SCORE = b.SCORE,
                                    PRICE = b.PRICE,
                                    DISCOUNT = b.DISCOUNT,
                                    PATH = c.PATH
                                };
                var resRank = queryRank.ToList();

                //Good reputation
                var queryScore = from b in context.books
                                 join c in context.pictures on b.BOOKID equals c.BOOKID
                                 join d in context.writes on b.BOOKID equals d.BOOKID
                                 join e in context.authors on d.AUTHORID equals e.AUTHORID
                                 orderby b.SCORE descending
                                 select new HomeBookInfo()
                                 {
                                     NAME = b.NAME,
                                     AUTHORNAME = e.NAME,
                                     SCORE = b.SCORE,
                                     PRICE = b.PRICE,
                                     DISCOUNT = b.DISCOUNT,
                                     PATH = c.PATH
                                 };
                var resScore = queryScore.ToList();

                //Latest
                var queryLatest = from b in context.books
                                  join c in context.pictures on b.BOOKID equals c.BOOKID
                                  join d in context.writes on b.BOOKID equals d.BOOKID
                                  join e in context.authors on d.AUTHORID equals e.AUTHORID
                                  orderby b.PUBLISHINGDATE descending
                                  select new HomeBookInfo()
                                  {
                                      NAME = b.NAME,
                                      AUTHORNAME = e.NAME,
                                      SCORE = b.SCORE,
                                      PRICE = b.PRICE,
                                      DISCOUNT = b.DISCOUNT,
                                      PATH = c.PATH
                                  };
                var resLatest = queryLatest.ToList();



                for (int i = 0; i < 10; i++)
                {
                    HomeVM.bpsLit.Add(resLit[i]);
                    HomeVM.bpsPop.Add(resPop[i]);
                    HomeVM.bpsCul.Add(resCul[i]);
                    HomeVM.bpsLif.Add(resLif[i]);
                    HomeVM.bpsEco.Add(resEco[i]);
                    HomeVM.bpsTec.Add(resTec[i]);
                    HomeVM.bpsRank.Add(resRank[i]);
                    HomeVM.bpsScore.Add(resScore[i]);
                    HomeVM.bpsLatest.Add(resLatest[i]);
                }

            }

            return View(HomeVM);
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}