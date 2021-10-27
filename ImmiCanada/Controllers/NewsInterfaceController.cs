using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ImmiCanada.Entities;

namespace ImmiCanada.Controllers
{
    public class NewsInterfaceController : BaseController
    {
        private ImmiCanadaEntities db = new ImmiCanadaEntities();
        readonly int ITEMPERPAGE = 6;
        // GET: Service
        public ActionResult Index(int page = 1)
        {
            ViewData["submenuActive"] = "NewsIndex";

            double count = Convert.ToDouble(db.News.Where(i => i.TypeId == 4).Count()) / ITEMPERPAGE;
            int totalPage = Convert.ToInt32(Math.Ceiling(count));
            ViewData["totalPage"] = totalPage;
            ViewData["NewsList"] = db.News.Where(i => i.TypeId == 4).OrderByDescending(i => i.CreatedDate).Skip((page - 1) * ITEMPERPAGE).Take(ITEMPERPAGE).ToList();

            return View();
        }

        public ActionResult NewsImmigrationStory(int page = 1)
        {
            ViewData["submenuActive"] = "NewsImmigrationStory";

            double count = Convert.ToDouble(db.News.Where(i => i.TypeId == 5).Count()) / ITEMPERPAGE;
            int totalPage = Convert.ToInt32(Math.Ceiling(count));
            ViewData["totalPage"] = totalPage;
            ViewData["NewsList"] = db.News.Where(i => i.TypeId == 5).OrderByDescending(i => i.CreatedDate).Skip((page - 1) * ITEMPERPAGE).Take(ITEMPERPAGE).ToList();

            return View();
        }

        public ActionResult NewsStudyAboard(int page = 1)
        {
            ViewData["submenuActive"] = "NewsStudyAboard";

            double count = Convert.ToDouble(db.News.Where(i => i.TypeId == 1).Count()) / ITEMPERPAGE;
            int totalPage = Convert.ToInt32(Math.Ceiling(count));
            ViewData["totalPage"] = totalPage;
            ViewData["NewsList"] = db.News.Where(i => i.TypeId == 1).OrderByDescending(i => i.CreatedDate).Skip((page - 1) * ITEMPERPAGE).Take(ITEMPERPAGE).ToList();

            return View();
        }

        public ActionResult NewsTravelling(int page = 1)
        {
            ViewData["submenuActive"] = "NewsTravelling";

            double count = Convert.ToDouble(db.News.Where(i => i.TypeId == 2).Count()) / ITEMPERPAGE;
            int totalPage = Convert.ToInt32(Math.Ceiling(count));
            ViewData["totalPage"] = totalPage;
            ViewData["NewsList"] = db.News.Where(i => i.TypeId == 2).OrderByDescending(i => i.CreatedDate).Skip((page - 1) * ITEMPERPAGE).Take(ITEMPERPAGE).ToList();

            return View();
        }

        public ActionResult NewsPolitics(int page = 1)
        {
            ViewData["submenuActive"] = "NewsPolitics";

            double count = Convert.ToDouble(db.News.Where(i => i.TypeId == 3).Count()) / ITEMPERPAGE;
            int totalPage = Convert.ToInt32(Math.Ceiling(count));
            ViewData["totalPage"] = totalPage;
            ViewData["NewsList"] = db.News.Where(i => i.TypeId == 3).OrderByDescending(i => i.CreatedDate).Skip((page - 1) * ITEMPERPAGE).Take(ITEMPERPAGE).ToList();

            return View();
        }

        public ActionResult Detail(int id)
        {
            ViewData["submenuActive"] = "NewsIndex";
            var News = db.News.FirstOrDefault(i => i.Id == id);
            return View(News);
        }

        public ActionResult PartialNewsIndex()
        {
            ViewData["NewsIndex"] = db.News.Where(i => i.TypeId == 4).OrderByDescending(i => i.CreatedDate).Take(6).ToList();
            return PartialView();
        }

        public ActionResult PartialNewsImmigration()
        {
            ViewData["NewsImmigration"] = db.News.Where(i => i.TypeId == 5).OrderByDescending(i => i.CreatedDate).Take(6).ToList();
            return PartialView();
        }

        public ActionResult PartialNewsImmigrationStory()
        {
            ViewData["NewsImmigrationStory"] = db.News.Where(i => i.TypeId == 5).OrderByDescending(i => i.CreatedDate).Take(6).ToList();
            return PartialView();
        }

        public ActionResult PartialNewsStudyAboard()
        {
            ViewData["NewsStudyAboard"] = db.News.Where(i => i.TypeId == 1).OrderByDescending(i => i.CreatedDate).Take(5).ToList();
            return PartialView();
        }

        public ActionResult PartialNewsTravelling()
        {
            ViewData["NewsTravelling"] = db.News.Where(i => i.TypeId == 2).OrderByDescending(i => i.CreatedDate).Take(5).ToList();
            return PartialView();
        }

        public ActionResult PartialNewsPolitics()
        {
            ViewData["NewsPolitics"] = db.News.Where(i => i.TypeId == 3).OrderByDescending(i => i.CreatedDate).Take(5).ToList();
            return PartialView();
        }

        public ActionResult PartialNewsList(List<News> NewsList, int totalPage)
        {
            ViewData["NewsList"] = NewsList;
            ViewData["TotalPage"] = totalPage;
            return PartialView();
        }

        public ActionResult PartialNewsDetail(News News)
        {
            return PartialView(News);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
