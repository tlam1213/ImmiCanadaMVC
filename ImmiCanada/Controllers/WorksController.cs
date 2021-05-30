﻿using System;
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
    public class WorksController : Controller
    {
        private ImmiCanadaEntities db = new ImmiCanadaEntities();

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
            return View();
        }

        // POST: Works/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WorkId,ImmigrationServiceId,NocId,Income,Experience,Position,Certificate,WorkType,NumberOfRecruitments,Sex,Occupation,Age,Detail,Benefic,NumberOfView,Base64Image")] Work work)
        {
            if (ModelState.IsValid)
            {
                db.Works.Add(work);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ImmigrationServiceId = new SelectList(db.ImmigrationServices, "Id", "Title", work.ImmigrationServiceId);
            ViewBag.NocId = new SelectList(db.Nocs, "NocId", "Title", work.NocId);
            return View(work);
        }

        // GET: Works/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.ImmigrationServiceId = new SelectList(db.ImmigrationServices, "Id", "Title", work.ImmigrationServiceId);
            ViewBag.NocId = new SelectList(db.Nocs, "NocId", "Title", work.NocId);
            return View(work);
        }

        // POST: Works/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WorkId,ImmigrationServiceId,NocId,Income,Experience,Position,Certificate,WorkType,NumberOfRecruitments,Sex,Occupation,Age,Detail,Benefic,NumberOfView,Base64Image")] Work work)
        {
            if (ModelState.IsValid)
            {
                db.Entry(work).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ImmigrationServiceId = new SelectList(db.ImmigrationServices, "Id", "Title", work.ImmigrationServiceId);
            ViewBag.NocId = new SelectList(db.Nocs, "NocId", "Title", work.NocId);
            return View(work);
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
    }
}
