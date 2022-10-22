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
    public class StateInterfaceController : BaseController
    {
        private ImmiCanadaEntities db = new ImmiCanadaEntities();
        
        public ActionResult Ontario()
        {
            ViewData["mainbanner"] = "/Content/images/States/Ontario/banner-ontario.jpg";
            return View();
        }

        public ActionResult Alberta()
        {
            ViewData["mainbanner"] = "/Content/images/States/Alberta/1_banner_alberta.jpg";
            return View();
        }

        public ActionResult BritishColumbia()
        {
            ViewData["mainbanner"] = "/Content/images/States/BritishColumbia/1-1-columbia-banner.jpg";
            return View();
        }

        public ActionResult Manitoba()
        {
            ViewData["mainbanner"] = "/Content/images/States/Manitoba/1-banner-manitoba.jpg";
            return View();
        }

        public ActionResult NewBrun()
        {
            ViewData["mainbanner"] = "/Content/images/States/NewBrun/1-banner-new-brunswicks.jpg";
            return View();
        }
        public ActionResult NL()
        {
            ViewData["mainbanner"] = "/Content/images/States/NL/1-banner-newfoundland.jpg";
            return View();
        }

        public ActionResult Nova()
        {
            ViewData["mainbanner"] = "/Content/images/States/Nova/1-banner-nova-scotia.jpg";
            return View();
        }

        public ActionResult PEI()
        {
            ViewData["mainbanner"] = "/Content/images/States/PEI/1-banner-pei.jpg";
            return View();
        }
        public ActionResult Quebec()
        {
            ViewData["mainbanner"] = "/Content/images/States/Quebec/1-banner-quebec.jpg";
            return View();
        }

        public ActionResult Saskatchewan()
        {
            ViewData["mainbanner"] = "/Content/images/States/Saskatchewan/1-banner-saskatchewan.jpg";
            return View();
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
