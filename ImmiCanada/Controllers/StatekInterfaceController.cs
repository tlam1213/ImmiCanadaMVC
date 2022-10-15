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
