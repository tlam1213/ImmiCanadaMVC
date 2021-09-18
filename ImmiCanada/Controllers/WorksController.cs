using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ImmiCanada.Entities;

namespace ImmiCanada.Controllers
{
    public class WorksController : Controller
    {
        private ImmiCanadaEntities db = new ImmiCanadaEntities();

        private static Work workOriginal;

        // GET: Works
        public ActionResult Index()
        {
            var works = db.Works.Include(w => w.ImmigrationService).Include(w => w.Noc);
            return View(works.ToList());
        }

        // GET: Works/Details/5
        public ActionResult Details(int? id)
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

        // GET: Works/Create
        public ActionResult Create()
        {
            ViewBag.ImmigrationServiceId = new SelectList(db.ImmigrationServices, "Id", "Title");
            ViewBag.NocId = new SelectList(db.Nocs, "NocId", "Title");
            ViewBag.PositionId = new SelectList(db.Positions, "Id", "Name");
            ViewBag.OccupationId = new SelectList(db.Occupations, "Id", "Name");
            return View();
        }

        // POST: Works/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(Work work, HttpPostedFileBase Base64Image)
        {
            workOriginal = null;
            work.Base64Image = getBase64Image(Base64Image);
            db.Works.Add(work);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            workOriginal = db.Works.Find(id);
            if (workOriginal == null)
            {
                return HttpNotFound();
            }
            ViewBag.ImmigrationServiceId = new SelectList(db.ImmigrationServices, "Id", "Title", workOriginal.ImmigrationServiceId);
            ViewBag.NocId = new SelectList(db.Nocs, "NocId", "Title", workOriginal.NocId);
            ViewBag.PositionId = new SelectList(db.Positions, "Id", "Name", workOriginal.PositionId);
            ViewBag.OccupationId = new SelectList(db.Occupations, "Id", "Name", workOriginal.OccupationId);
            return View(workOriginal);
        }

        // POST: Works/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(Work work, HttpPostedFileBase Base64Image)
        {
            work.Base64Image = getBase64Image(Base64Image);            
            db.Entry(work).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Works/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Works/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Work work = db.Works.Find(id);
            db.Works.Remove(work);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private String getBase64Image(HttpPostedFileBase img)
        {
            if (img == null || img.ContentLength == 0)
            {
                return workOriginal != null ? workOriginal.Base64Image : "";
            }
            byte[] fileInBytes = new byte[img.ContentLength];
            using (BinaryReader theReader = new BinaryReader(img.InputStream))
            {
                fileInBytes = theReader.ReadBytes(img.ContentLength);
            }
            return String.Format("data:{0};base64,{1}", img.ContentType, Convert.ToBase64String(fileInBytes));
        }
    }
}
