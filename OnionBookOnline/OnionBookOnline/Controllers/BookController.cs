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
        public ActionResult Index(string id)
        {
            var bkVM = new BookViewModel();
            using (var context = new OnionContext())
            {
                var query = from b in context.books
                            join c in context.pictures on b.BOOKID equals c.BOOKID
                            join d in context.writes on b.BOOKID equals d.BOOKID
                            join e in context.authors on d.AUTHORID equals e.AUTHORID
                            where b.BOOKID == id
                            select new Detailbook()
                            {
                                ID = b.BOOKID,
                                NAME = b.NAME,
                                ISBN = b.ISBN,
                                PRIMARYID = b.PRIMARYID,
                                PUBLISHER = b.PUBLISHER,
                                PAGES = b.PAGES,
                                PUBLISHINGDATE = b.PUBLISHINGDATE,
                                STOCK = b.STOCK,
                                SCORE = b.SCORE,
                                PRICE = b.PRICE,
                                DISCOUNT = b.DISCOUNT,
                                SALE = b.SALE,
                                PATH = c.PATH,
                                AUTHOR = e.NAME,
                                INTRODUCTION=b.INTRODUCTION,
                                SECONDARYID = b.SECONDARYID
                            };
                var res = query.First();
                bkVM.detailBook = res;
            }
            return View(bkVM);
        }

        //        [HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Index(string id, string userId, int amount)
        //{
        //    using(var context = new OnionContext())
        //    {
        //        var preOrder = new PREORDER()
        //        {
        //            CUSTOMERID = userId,
        //            BOOKID = id,
        //            AMOUNT = amount,
        //        };
        //        context.preorders.Add(preOrder);
        //        int x = await(context.SaveChangesAsync());
        //    }
        //    ViewBag.Message = "添加成功！";
        //    return View();
        //}

        ////GET:Book/
        //public async Task<ActionResult> Index(string id, string userId)
        //{
        //    using (var context = new OnionContext())
        //    {
        //        var star = new STAR()
        //        {
        //            CUSTOMERID = userId,
        //            BOOKID = id,
        //            TIME = DateTime.Now.Date.ToString(),
        //        };
        //        context.stars.Add(star);
        //        int x = await (context.SaveChangesAsync());
        //    }
        //    ViewBag.Message = "添加成功！";
        //    return View();
        //}

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
                                            PRIMARYID = b.PRIMARYID,
                                            PUBLISHER = b.PUBLISHER,
                                            PAGES = b.PAGES,
                                            PUBLISHINGDATE = b.PUBLISHINGDATE,
                                            STOCK = b.STOCK,
                                            SCORE = b.SCORE,
                                            PRICE = b.PRICE,
                                            DISCOUNT = b.DISCOUNT,
                                            SALE = b.SALE,
                                            PATH = c.PATH,
                                            AUTHOR = e.NAME,
                                            INTRODUCTION = b.INTRODUCTION,
                                            SECONDARYID = b.SECONDARYID
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
                                            PRIMARYID = b.PRIMARYID,
                                            PUBLISHER = b.PUBLISHER,
                                            PAGES = b.PAGES,
                                            PUBLISHINGDATE = b.PUBLISHINGDATE,
                                            STOCK = b.STOCK,
                                            SCORE = b.SCORE,
                                            PRICE = b.PRICE,
                                            DISCOUNT = b.DISCOUNT,
                                            SALE = b.SALE,
                                            PATH = c.PATH,
                                            AUTHOR = e.NAME,
                                            INTRODUCTION = b.INTRODUCTION,
                                            SECONDARYID = b.SECONDARYID
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
                                            PRIMARYID = b.PRIMARYID,
                                            PUBLISHER = b.PUBLISHER,
                                            PAGES = b.PAGES,
                                            PUBLISHINGDATE = b.PUBLISHINGDATE,
                                            STOCK = b.STOCK,
                                            SCORE = b.SCORE,
                                            PRICE = b.PRICE,
                                            DISCOUNT = b.DISCOUNT,
                                            SALE = b.SALE,
                                            PATH = c.PATH,
                                            AUTHOR = e.NAME,
                                            INTRODUCTION = b.INTRODUCTION,
                                            SECONDARYID = b.SECONDARYID
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
                                            PRIMARYID = b.PRIMARYID,
                                            PUBLISHER = b.PUBLISHER,
                                            PAGES = b.PAGES,
                                            PUBLISHINGDATE = b.PUBLISHINGDATE,
                                            STOCK = b.STOCK,
                                            SCORE = b.SCORE,
                                            PRICE = b.PRICE,
                                            DISCOUNT = b.DISCOUNT,
                                            SALE = b.SALE,
                                            PATH = c.PATH,
                                            AUTHOR = e.NAME,
                                            INTRODUCTION = b.INTRODUCTION,
                                            SECONDARYID = b.SECONDARYID
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
                                PRIMARYID = b.PRIMARYID,
                                PUBLISHER = b.PUBLISHER,
                                PAGES = b.PAGES,
                                PUBLISHINGDATE = b.PUBLISHINGDATE,
                                STOCK = b.STOCK,
                                SCORE = b.SCORE,
                                PRICE = b.PRICE,
                                DISCOUNT = b.DISCOUNT,
                                SALE = b.SALE,
                                PATH = c.PATH,
                                AUTHOR = e.NAME,
                                INTRODUCTION = b.INTRODUCTION,
                                SECONDARYID = b.SECONDARYID
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
                                PRIMARYID = b.PRIMARYID,
                                PUBLISHER = b.PUBLISHER,
                                PAGES = b.PAGES,
                                PUBLISHINGDATE = b.PUBLISHINGDATE,
                                STOCK = b.STOCK,
                                SCORE = b.SCORE,
                                PRICE = b.PRICE,
                                DISCOUNT = b.DISCOUNT,
                                SALE = b.SALE,
                                PATH = c.PATH,
                                AUTHOR = e.NAME,
                                INTRODUCTION = b.INTRODUCTION,
                                SECONDARYID = b.SECONDARYID
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
                                PRIMARYID = b.PRIMARYID,
                                PUBLISHER = b.PUBLISHER,
                                PAGES = b.PAGES,
                                PUBLISHINGDATE = b.PUBLISHINGDATE,
                                STOCK = b.STOCK,
                                SCORE = b.SCORE,
                                PRICE = b.PRICE,
                                DISCOUNT = b.DISCOUNT,
                                SALE=b.SALE,
                                PATH = c.PATH,
                                AUTHOR = e.NAME,
                                INTRODUCTION = b.INTRODUCTION,
                                SECONDARYID=b.SECONDARYID
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

        public ActionResult Type(string typename)
        {
            var bkVM = new BookViewModel();
            using (var context = new OnionContext())
            {
                string pID=null, sID=null;
                typename = typename.Replace("/", "");
                switch (typename)
                {
                    case "fiction": { pID = "01";sID = "01";break; }
                    case "scatter": { pID = "01"; sID = "02"; break; }
                    case "prose": { pID = "01"; sID = "03"; break; }
                    case "poetry": { pID = "01"; sID = "04"; break; }
                    case "fairytale": { pID = "01"; sID = "05"; break; }
                    case "essay": { pID = "01"; sID = "06"; break; }
                    case "child": { pID = "01"; sID = "07"; break; }
                    case "masterpiece": { pID = "01"; sID = "08"; break; }
                    case "comic": { pID = "02"; sID = "01"; break; }
                    case "painting": { pID = "02"; sID = "02"; break; }
                    case "romance": { pID = "02"; sID = "03"; break; }
                    case "reasoning": { pID = "02"; sID = "04"; break; }
                    case "sf": { pID = "02"; sID = "05"; break; }
                    case "ma": { pID = "02"; sID = "06"; break; }
                    case "youthfulness": { pID = "02"; sID = "07"; break; }
                    case "suspense": { pID = "02"; sID = "08"; break; }
                    case "history": { pID = "03"; sID = "01"; break; }
                    case "psychological": { pID = "03"; sID = "02"; break; }
                    case "society": { pID = "03"; sID = "03"; break; }
                    case "philosophy": { pID = "03"; sID = "04"; break; }
                    case "art": { pID = "03"; sID = "05"; break; }
                    case "politics": { pID = "03"; sID = "06"; break; }
                    case "building": { pID = "03"; sID = "07"; break; }
                    case "religion": { pID = "03"; sID = "08"; break; }
                    case "travel": { pID = "04"; sID = "01"; break; }
                    case "photography": { pID = "04"; sID = "02"; break; }
                    case "food": { pID = "04"; sID = "03"; break; }
                    case "health": { pID = "04"; sID = "04"; break; }
                    case "education": { pID = "04"; sID = "05"; break; }
                    case "home": { pID = "04"; sID = "06"; break; }
                    case "workplace": { pID = "04"; sID = "07"; break; }
                    case "gender": { pID = "04"; sID = "08"; break; }
                    case "economic": { pID = "05"; sID = "01"; break; }
                    case "management": { pID = "05"; sID = "02"; break; }
                    case "financial": { pID = "05"; sID = "03"; break; }
                    case "investment": { pID = "05"; sID = "04"; break; }
                    case "marketing": { pID = "05"; sID = "05"; break; }
                    case "fm": { pID = "05"; sID = "06"; break; }
                    case "stock": { pID = "05"; sID = "07"; break; }
                    case "ad": { pID = "05"; sID = "08"; break; }
                    case "sc": { pID = "06"; sID = "01"; break; }
                    case "science": { pID = "06"; sID = "02"; break; }
                    case "interaction": { pID = "06"; sID = "03"; break; }
                    case "programming": { pID = "06"; sID = "04"; break; }
                    case "algorithms": { pID = "06"; sID = "05"; break; }
                    case "communication": { pID = "06"; sID = "06"; break; }
                    case "program": { pID = "06"; sID = "07"; break; }
                    case "internet": { pID = "06"; sID = "08"; break; }
                }


                var query = from b in context.books
                            join c in context.pictures on b.BOOKID equals c.BOOKID
                            join d in context.writes on b.BOOKID equals d.BOOKID
                            join e in context.authors on d.AUTHORID equals e.AUTHORID
                            where (b.PRIMARYID==pID)&&(b.SECONDARYID==sID)
                            select new Detailbook()
                            {
                                ID = b.BOOKID,
                                NAME = b.NAME,
                                ISBN = b.ISBN,
                                PRIMARYID = b.PRIMARYID,
                                PUBLISHER = b.PUBLISHER,
                                PAGES = b.PAGES,
                                PUBLISHINGDATE = b.PUBLISHINGDATE,
                                STOCK = b.STOCK,
                                SCORE = b.SCORE,
                                PRICE = b.PRICE,
                                DISCOUNT = b.DISCOUNT,
                                SALE = b.SALE,
                                PATH = c.PATH,
                                AUTHOR = e.NAME,
                                INTRODUCTION = b.INTRODUCTION,
                                SECONDARYID = b.SECONDARYID
                            };
                bkVM.typeBook = new List<Detailbook>(query.ToList());
            }
            return View(bkVM);
        }
    }
}
