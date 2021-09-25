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
        readonly int ITEMPERPAGE = 10;
        // GET: Service
        public ActionResult Index()
        {
            ViewData["submenuActive"] = "NewsIndex";
            return View();
        }

        public ActionResult NewsImmigrationStory()
        {
            ViewData["submenuActive"] = "NewsImmigrationStory";
            return View();
        }

        public ActionResult NewsStudyAboard()
        {
            ViewData["submenuActive"] = "NewsStudyAboard";
            return View();
        }

        public ActionResult NewsTravelling()
        {
            ViewData["submenuActive"] = "NewsTravelling";
            return View();
        }

        public ActionResult PartialNewsIndex()
        {
            return PartialView();
        }

        public ActionResult PartialNewsImmigration()
        {
            return PartialView();
        }

        public ActionResult PartialNewsImmigrationStory()
        {
            return PartialView();
        }

        public ActionResult PartialNewsStudyAboard()
        {
            return PartialView();
        }

        public ActionResult PartialNewsTravelling()
        {
            return PartialView();
        }

        public ActionResult PartialNewsList()
        {
            return PartialView();
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
