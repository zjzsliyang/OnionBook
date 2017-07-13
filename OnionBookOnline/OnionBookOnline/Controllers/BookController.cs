using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnionBookOnline.Models;
using OnionBookOnline.DAL;
using System.Threading.Tasks;

namespace OnionBookOnline.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        //public ActionResult Index(string id)
        //{
        //    var bkVM = new BookViewModel();
        //    using (var context = new OnionContext())
        //    {
        //        var query = from b in context.books
        //                    join c in context.pictures on b.BOOKID equals c.BOOKID
        //                    join d in context.writes on b.BOOKID equals d.BOOKID
        //                    join e in context.authors on d.AUTHORID equals e.AUTHORID
        //                    where b.BOOKID == id
        //                    select new Detailbook()
        //                    {
        //                        ID = b.BOOKID,
        //                        NAME = b.NAME,
        //                        ISBN = b.ISBN,
        //                        CATEGORYID = b.PRIMARYID,
        //                        PUBLISHER = b.PUBLISHER,
        //                        PAGES = b.PAGES,
        //                        PUBLISHINGDATE = b.PUBLISHINGDATE,
        //                        STOCK = b.STOCK,
        //                        SCORE = b.SCORE,
        //                        PRICE = b.PRICE,
        //                        DISCOUNT = b.DISCOUNT,
        //                        SALE = b.SALE,
        //                        PATH = c.PATH,
        //                        AUTHOR = e.NAME
        //                    };
        //        var res = query.First();
        //        bkVM.detailBook = res;
        //    }
        //    return View(bkVM);
        //}

//        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(string id, string userId, int amount)
        {
            using(var context = new OnionContext())
            {
                var preOrder = new PREORDER()
                {
                    CUSTOMERID = userId,
                    BOOKID = id,
                    AMOUNT = amount,
                };
                context.preorders.Add(preOrder);
                int x = await(context.SaveChangesAsync());
            }
            ViewBag.Message = "添加成功！";
            return View();
        }

        public ActionResult Search(string standard, string keywords)
        {
            var bkVM = new BookViewModel();
            ViewBag.keywords = keywords;
            switch (standard)
            {
                case "bookname":
                    {
                        using (var context = new OnionContext())
                        {
                            var query = from b in context.books
                                        join c in context.pictures on b.BOOKID equals c.BOOKID
                                        join d in context.writes on b.BOOKID equals d.BOOKID
                                        join e in context.authors on d.AUTHORID equals e.AUTHORID
                                        where b.NAME.Contains(keywords)
                                        select new Detailbook()
                                        {
                                            ID = b.BOOKID,
                                            NAME = b.NAME,
                                            ISBN = b.ISBN,
                                            CATEGORYID = b.PRIMARYID,
                                            PUBLISHER = b.PUBLISHER,
                                            PAGES = b.PAGES,
                                            PUBLISHINGDATE = b.PUBLISHINGDATE,
                                            STOCK = b.STOCK,
                                            SCORE = b.SCORE,
                                            PRICE = b.PRICE,
                                            DISCOUNT = b.DISCOUNT,
                                            SALE = b.SALE,
                                            PATH = c.PATH,
                                            AUTHOR = e.NAME
                                        };
                            bkVM.srcBook = new List<Detailbook>(query.ToList());
                        }
                        return View(bkVM);
                    }
                case "author"://nature join
                    {
                        using (var context = new OnionContext())
                        {
                            var query = from b in context.books
                                        join c in context.pictures on b.BOOKID equals c.BOOKID
                                        join d in context.writes on b.BOOKID equals d.BOOKID
                                        join e in context.authors on d.AUTHORID equals e.AUTHORID
                                        where e.NAME.Contains(keywords)
                                        select new Detailbook()
                                        {
                                            ID = b.BOOKID,
                                            NAME = b.NAME,
                                            ISBN = b.ISBN,
                                            CATEGORYID = b.PRIMARYID,
                                            PUBLISHER = b.PUBLISHER,
                                            PAGES = b.PAGES,
                                            PUBLISHINGDATE = b.PUBLISHINGDATE,
                                            STOCK = b.STOCK,
                                            SCORE = b.SCORE,
                                            PRICE = b.PRICE,
                                            DISCOUNT = b.DISCOUNT,
                                            SALE = b.SALE,
                                            PATH = c.PATH,
                                            AUTHOR = e.NAME
                                        };
                            bkVM.srcBook = new List<Detailbook>(query.ToList());
                        }
                        return View(bkVM);
                    }
                case "publisher":
                    {
                        using (var context = new OnionContext())
                        {
                            var query = from b in context.books
                                        join c in context.pictures on b.BOOKID equals c.BOOKID
                                        join d in context.writes on b.BOOKID equals d.BOOKID
                                        join e in context.authors on d.AUTHORID equals e.AUTHORID
                                        where b.PUBLISHER.Contains(keywords)
                                        select new Detailbook()
                                        {
                                            ID = b.BOOKID,
                                            NAME = b.NAME,
                                            ISBN = b.ISBN,
                                            CATEGORYID = b.PRIMARYID,
                                            PUBLISHER = b.PUBLISHER,
                                            PAGES = b.PAGES,
                                            PUBLISHINGDATE = b.PUBLISHINGDATE,
                                            STOCK = b.STOCK,
                                            SCORE = b.SCORE,
                                            PRICE = b.PRICE,
                                            DISCOUNT = b.DISCOUNT,
                                            SALE = b.SALE,
                                            PATH = c.PATH,
                                            AUTHOR = e.NAME
                                        };
                            bkVM.srcBook = new List<Detailbook>(query.ToList());
                        }
                        return View(bkVM);
                    }
                case "isbn":
                    {
                        using (var context = new OnionContext())
                        {
                            var query = from b in context.books
                                        join c in context.pictures on b.BOOKID equals c.BOOKID
                                        join d in context.writes on b.BOOKID equals d.BOOKID
                                        join e in context.authors on d.AUTHORID equals e.AUTHORID
                                        where b.ISBN.Contains(keywords)
                                        select new Detailbook()
                                        {
                                            ID = b.BOOKID,
                                            NAME = b.NAME,
                                            ISBN = b.ISBN,
                                            CATEGORYID = b.PRIMARYID,
                                            PUBLISHER = b.PUBLISHER,
                                            PAGES = b.PAGES,
                                            PUBLISHINGDATE = b.PUBLISHINGDATE,
                                            STOCK = b.STOCK,
                                            SCORE = b.SCORE,
                                            PRICE = b.PRICE,
                                            DISCOUNT = b.DISCOUNT,
                                            SALE = b.SALE,
                                            PATH = c.PATH,
                                            AUTHOR = e.NAME
                                        };
                            bkVM.srcBook = new List<Detailbook>(query.ToList());
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
                var query = from b in context.books
                            join c in context.pictures on b.BOOKID equals c.BOOKID
                            join d in context.writes on b.BOOKID equals d.BOOKID
                            join e in context.authors on d.AUTHORID equals e.AUTHORID
                            select new Detailbook()
                            {
                                ID = b.BOOKID,
                                NAME = b.NAME,
                                ISBN = b.ISBN,
                                CATEGORYID = b.PRIMARYID,
                                PUBLISHER = b.PUBLISHER,
                                PAGES = b.PAGES,
                                PUBLISHINGDATE = b.PUBLISHINGDATE,
                                STOCK = b.STOCK,
                                SCORE = b.SCORE,
                                PRICE = b.PRICE,
                                DISCOUNT = b.DISCOUNT,
                                SALE = b.SALE,
                                PATH = c.PATH,
                                AUTHOR = e.NAME
                            };
                bkVM.recBook = new List<Detailbook>(query.ToList());
                query = query.OrderBy(a => a.SCORE);
                var res = query.ToList();
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
                var query = from b in context.books
                            join c in context.pictures on b.BOOKID equals c.BOOKID
                            join d in context.writes on b.BOOKID equals d.BOOKID
                            join e in context.authors on d.AUTHORID equals e.AUTHORID
                            select new Detailbook()
                            {
                                ID = b.BOOKID,
                                NAME = b.NAME,
                                ISBN = b.ISBN,
                                CATEGORYID = b.PRIMARYID,
                                PUBLISHER = b.PUBLISHER,
                                PAGES = b.PAGES,
                                PUBLISHINGDATE = b.PUBLISHINGDATE,
                                STOCK = b.STOCK,
                                SCORE = b.SCORE,
                                PRICE = b.PRICE,
                                DISCOUNT = b.DISCOUNT,
                                SALE = b.SALE,
                                PATH = c.PATH,
                                AUTHOR = e.NAME
                            };
                bkVM.newBook = new List<Detailbook>(query.ToList());
                query = query.OrderBy(a => a.PUBLISHINGDATE);
                var res = query.ToList();
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
                var query = from b in context.books
                            join c in context.pictures on b.BOOKID equals c.BOOKID
                            join d in context.writes on b.BOOKID equals d.BOOKID
                            join e in context.authors on d.AUTHORID equals e.AUTHORID
                            select new Detailbook()
                            {
                                ID = b.BOOKID,
                                NAME = b.NAME,
                                ISBN = b.ISBN,
                                CATEGORYID = b.PRIMARYID,
                                PUBLISHER = b.PUBLISHER,
                                PAGES = b.PAGES,
                                PUBLISHINGDATE = b.PUBLISHINGDATE,
                                STOCK = b.STOCK,
                                SCORE = b.SCORE,
                                PRICE = b.PRICE,
                                DISCOUNT = b.DISCOUNT,
                                SALE=b.SALE,
                                PATH = c.PATH,
                                AUTHOR = e.NAME
                            };
                bkVM.hotBook = new List<Detailbook>(query.ToList());
                query = query.OrderBy(a => a.SALE);
                var res = query.ToList();
                for (int i = 0; i < 10; ++i)
                {
                    bkVM.hotBook.Add(res[i]);
                }
            }
            return View(bkVM);
        }

        public ActionResult Type()
        {
            return View();
        }
    }
}
