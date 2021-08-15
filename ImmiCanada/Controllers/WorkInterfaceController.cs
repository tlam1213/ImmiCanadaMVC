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
    public class WorkInterfaceController : BaseController
    {
        private ImmiCanadaEntities db = new ImmiCanadaEntities();
        readonly int ITEMPERPAGE = 10;
        // GET: Service
        public ActionResult Index()
        {
            double count = Convert.ToDouble(db.Works.Count()) / ITEMPERPAGE;
            int totalPage = Convert.ToInt32(Math.Ceiling(count));
            ViewData["totalPage"] = totalPage;
            ViewData["works"] = db.Works.OrderByDescending(i => i.WorkId).Take(ITEMPERPAGE).ToList();
            return View();
        }

        public ActionResult Search(int page = 1)
        {
            double count = Convert.ToDouble(db.Works.Count()) / ITEMPERPAGE;
            int totalPage = Convert.ToInt32(Math.Ceiling(count));
            ViewData["totalPage"] = totalPage;
            ViewData["works"] = db.Works.OrderByDescending(i => i.WorkId).Skip((page - 1) * ITEMPERPAGE).Take(ITEMPERPAGE).ToList();
            return View("Index");
        }

        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Work work = db.Works.Find(id);
            if (work == null)
            {
                return HttpNotFound();
            }
            return View(work);
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
