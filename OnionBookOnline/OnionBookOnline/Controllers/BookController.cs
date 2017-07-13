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
        public string replaceNewLine(string src)
        {
            if (src.Contains("\\n"))
            {
                return src.Replace("\\n", Environment.NewLine);
            }
            else
                return src;
           
        }

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
                res.INTRODUCTION = replaceNewLine(res.INTRODUCTION);
                bkVM.detailBook = res;


                var q = from b in context.books
                            join c in context.pictures on b.BOOKID equals c.BOOKID
                            join d in context.writes on b.BOOKID equals d.BOOKID
                            join e in context.authors on d.AUTHORID equals e.AUTHORID
                            where e.NAME==res.AUTHOR 
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
                bkVM.relatedBook = new List<Detailbook>();
                //query = query.OrderByDescending(a => a.SCORE);
                var r = q.ToList();
                r.Remove(res);
                for (int i = 0; (i < 4 && i < r.Count()); ++i)
                {
                    r[i].INTRODUCTION = replaceNewLine(r[i].INTRODUCTION);
                    bkVM.relatedBook.Add(r[i]);
                }
                
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

        public ActionResult Recommend(int pages = 1)
        {
            var bkVM = new BookViewModel();
            using (var context = new OnionContext())
            {
                var query = from b in context.books
                            join c in context.pictures on b.BOOKID equals c.BOOKID
                            join d in context.writes on b.BOOKID equals d.BOOKID
                            join e in context.authors on d.AUTHORID equals e.AUTHORID
                            orderby b.SCORE descending
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
                bkVM.recBook = new List<Detailbook>();
                //query = query.OrderByDescending(a => a.SCORE);
                var res = query.ToList();
                for (int i = (pages-1)*10; (i < pages* 10&&i<res.Count()); ++i)
                {
                    res[i].INTRODUCTION = replaceNewLine(res[i].INTRODUCTION);
                    bkVM.recBook.Add(res[i]);
                }
                ViewBag.pages = Math.Ceiling(res.Count() / 10.0);
                ViewBag.currentPage = pages;
                ViewBag.addPage = pages + 1;
                ViewBag.minusPage = pages - 1;
            }
            return View(bkVM);
        }

        public ActionResult New(int pages=1)
        {
            var bkVM = new BookViewModel();
            using (var context = new OnionContext())
            {
                var query = from b in context.books
                            join c in context.pictures on b.BOOKID equals c.BOOKID
                            join d in context.writes on b.BOOKID equals d.BOOKID
                            join e in context.authors on d.AUTHORID equals e.AUTHORID
                            orderby b.PUBLISHINGDATE descending
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
                bkVM.newBook = new List<Detailbook>();
                //query = query.OrderByDescending(a => a.SCORE);
                var res = query.ToList();
                for (int i = (pages - 1) * 10; (i < pages * 10 && i < res.Count()); ++i)
                {
                    res[i].INTRODUCTION = replaceNewLine(res[i].INTRODUCTION);
                    bkVM.newBook.Add(res[i]);
                }
                ViewBag.pages = Math.Ceiling(res.Count()/10.0);
                ViewBag.currentPage = pages;
                ViewBag.addPage = pages + 1;
                ViewBag.minusPage = pages - 1;
            }
            return View(bkVM);
        }

        public ActionResult Hot(int pages=1)
        {
            var bkVM = new BookViewModel();
            using (var context = new OnionContext())
            {
                var query = from b in context.books
                            join c in context.pictures on b.BOOKID equals c.BOOKID
                            join d in context.writes on b.BOOKID equals d.BOOKID
                            join e in context.authors on d.AUTHORID equals e.AUTHORID
                            orderby b.SALE descending
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
                bkVM.hotBook = new List<Detailbook>();
                //query = query.OrderByDescending(a => a.SCORE);
                var res = query.ToList();
                for (int i = (pages - 1) * 10; (i < pages * 10 && i < res.Count()); ++i)
                {
                    res[i].INTRODUCTION = replaceNewLine(res[i].INTRODUCTION);
                    bkVM.hotBook.Add(res[i]);
                }
                ViewBag.pages = Math.Ceiling(res.Count() / 10.0);
                ViewBag.currentPage = pages;
                ViewBag.addPage = pages + 1;
                ViewBag.minusPage = pages - 1;
            }
            return View(bkVM);
        }

        public ActionResult Type(string typename,int pages=1)
        {
            var bkVM = new BookViewModel();
            using (var context = new OnionContext())
            {
                string pID = null, sID = null, chname = null;
                typename = typename.Replace("/", "");
                switch (typename)
                {
                    case "fiction": { pID = "01";sID = "01";chname = "小说"; break; }
                    case "scatter": { pID = "01"; sID = "02"; chname = "随笔"; break; }
                    case "prose": { pID = "01"; sID = "03"; chname = "散文"; break; }
                    case "poetry": { pID = "01"; sID = "04"; chname = "诗歌"; break; }
                    case "fairytale": { pID = "01"; sID = "05"; chname = "童话"; break; }
                    case "essay": { pID = "01"; sID = "06"; chname = "杂文"; break; }
                    case "child": { pID = "01"; sID = "07"; chname = "儿童"; break; }
                    case "masterpiece": { pID = "01"; sID = "08"; chname = "名著"; break; }

                    case "comic": { pID = "02"; sID = "01"; chname = "漫画"; break; }
                    case "painting": { pID = "02"; sID = "02"; chname = "绘本"; break; }
                    case "romance": { pID = "02"; sID = "03"; chname = "言情"; break; }
                    case "reasoning": { pID = "02"; sID = "04"; chname = "推理"; break; }
                    case "sf": { pID = "02"; sID = "05"; chname = "科幻"; break; }
                    case "ma": { pID = "02"; sID = "06"; chname = "武侠"; break; }
                    case "youthfulness": { pID = "02"; sID = "07"; chname = "青春"; break; }
                    case "suspense": { pID = "02"; sID = "08"; chname = "悬疑"; break; }

                    case "history": { pID = "03"; sID = "01"; chname = "历史"; break; }
                    case "psychological": { pID = "03"; sID = "02"; chname = "心理"; break; }
                    case "society": { pID = "03"; sID = "03"; chname = "社会"; break; }
                    case "philosophy": { pID = "03"; sID = "04"; chname = "哲学"; break; }
                    case "art": { pID = "03"; sID = "05"; chname = "艺术"; break; }
                    case "politics": { pID = "03"; sID = "06"; chname = "政治"; break; }
                    case "building": { pID = "03"; sID = "07"; chname = "建筑"; break; }
                    case "religion": { pID = "03"; sID = "08"; chname = "宗教"; break; }

                    case "travel": { pID = "04"; sID = "01"; chname = "旅行"; break; }
                    case "photography": { pID = "04"; sID = "02"; chname = "摄影"; break; }
                    case "food": { pID = "04"; sID = "03"; chname = "美食"; break; }
                    case "health": { pID = "04"; sID = "04"; chname = "健康"; break; }
                    case "education": { pID = "04"; sID = "05"; chname = "教育"; break; }
                    case "home": { pID = "04"; sID = "06"; chname = "家居"; break; }
                    case "workplace": { pID = "04"; sID = "07"; chname = "职场"; break; }
                    case "gender": { pID = "04"; sID = "08"; chname = "两性"; break; }

                    case "economic": { pID = "05"; sID = "01"; chname = "经济"; break; }
                    case "management": { pID = "05"; sID = "02"; chname = "管理"; break; }
                    case "financial": { pID = "05"; sID = "03"; chname = "金融"; break; }
                    case "investment": { pID = "05"; sID = "04"; chname = "投资"; break; }
                    case "marketing": { pID = "05"; sID = "05"; chname = "营销"; break; }
                    case "fm": { pID = "05"; sID = "06"; chname = "理财"; break; }
                    case "stock": { pID = "05"; sID = "07"; chname = "股票"; break; }
                    case "ad": { pID = "05"; sID = "08"; chname = "广告"; break; }

                    case "sc": { pID = "06"; sID = "01"; chname = "科普"; break; }
                    case "science": { pID = "06"; sID = "02"; chname = "科学"; break; }
                    case "interaction": { pID = "06"; sID = "03"; chname = "交互"; break; }
                    case "programming": { pID = "06"; sID = "04"; chname = "编程"; break; }
                    case "algorithms": { pID = "06"; sID = "05"; chname = "算法"; break; }
                    case "communication": { pID = "06"; sID = "06"; chname = "通信"; break; }
                    case "program": { pID = "06"; sID = "07"; chname = "程序"; break; }
                    case "internet": { pID = "06"; sID = "08"; chname = "互联网"; break; }
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
                bkVM.typeBook = new List<Detailbook>();
                //query = query.OrderByDescending(a => a.SCORE);
                var res = query.ToList();
                for (int i = (pages - 1) * 10; (i < pages * 10 && i < res.Count()); ++i)
                {
                    bkVM.typeBook.Add(res[i]);
                }
                ViewBag.pages = Math.Ceiling(res.Count() / 10.0);
                ViewBag.currentPage = pages;
                ViewBag.addPage = pages + 1;
                ViewBag.minusPage = pages - 1;
                bkVM.type = chname;
            }
            return View(bkVM);
        }
    }
}
