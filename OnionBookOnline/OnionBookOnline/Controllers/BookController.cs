using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnionBookOnline.Models;
using OnionBookOnline.DAL;

namespace OnionBookOnline.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index(string id)
        {
            var bkVM = new BookViewModel();
            using (var context = new OnionContext())
            {
                var query = from a in context.books
                            where a.BOOKID == id
                            select a;
                var res = query.First();
                bkVM.detailBook = res;

            }
            return View(bkVM);
        }

        public ActionResult Search(string standard, string keywords)
        {
            var bkVM = new BookViewModel();
            switch (standard)
            {
                case "bookname":
                    {
                        using (var context = new OnionContext())
                        {
                            var query = from a in context.books
                                        where a.NAME == keywords
                                        select a;
                            bkVM.srcBook = new List<BOOK>(query.ToList());
                        }
                        return View(bkVM);
                    }
                case "author"://nature join
                    {
                        using (var context = new OnionContext())
                        {
                            var query = from a in context.books
                                        where a.NAME == keywords
                                        select a;
                            bkVM.srcBook = new List<BOOK>(query.ToList());
                        }
                        return View(bkVM);
                    }
                case "publisher":
                    {
                        using (var context = new OnionContext())
                        {
                            var query = from a in context.books
                                        where a.PUBLISHER == keywords
                                        select a;
                            bkVM.srcBook = new List<BOOK>(query.ToList());
                        }
                        return View(bkVM);
                    }
                case "isbn":
                    {
                        using (var context = new OnionContext())
                        {
                            var query = from a in context.books
                                        where a.ISBN == keywords
                                        select a;
                            bkVM.srcBook = new List<BOOK>(query.ToList());
                        }
                        return View(bkVM);
                    }
                default:
                    return View();
            }
        }

        public ActionResult Recommend()
        {
            var bkVM = new BookViewModel();
            using (var context = new OnionContext())
            {
                var query = from a in context.books
                            select a;
                query = query.OrderBy(a => a.SCORE);
                var res = query.ToList();
                bkVM.recBook = new List<BOOK>();
                for (int i = 0; i < 10; ++i)
                {
                    bkVM.recBook.Add(res[i]);
                }
            }
            return View(bkVM);
        }

        public ActionResult New()
        {
            var bkVM = new BookViewModel();
            using (var context = new OnionContext())
            {
                var query = from a in context.books
                            select a;
                query = query.OrderBy(a => a.PUBLISHINGDATE);
                var res = query.ToList();
                bkVM.newBook = new List<BOOK>();
                for (int i = 0; i < 16; ++i)
                {
                    bkVM.newBook.Add(res[i]);
                }
            }
            return View(bkVM);
        }

        public ActionResult Hot()
        {
            var bkVM = new BookViewModel();
            using (var context = new OnionContext())
            {
                var query = from a in context.books
                            select a;
                query = query.OrderBy(a => a.SALE);
                var res = query.ToList();
                bkVM.hotBook = new List<BOOK>();
                for (int i = 0; i < 10; ++i)
                {
                    bkVM.hotBook.Add(res[i]);
                }
            }
            return View(bkVM);
        }
    }
}
