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
    public class ImmigrationServicesController : Controller
    {
        private ImmiCanadaEntities db = new ImmiCanadaEntities();

        private static ImmigrationService immigrationServiceOriginal;

        // GET: ImmigrationServices
        public ActionResult Index()
        {
            var immigrationServices = db.ImmigrationServices.Include(i => i.PermanentResident1).Include(i => i.State1).Include(i => i.ImmigrationServiceType);
            return View(immigrationServices.ToList());
        }

        // GET: ImmigrationServices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImmigrationService immigrationService = db.ImmigrationServices.Find(id);
            if (immigrationService == null)
            {
                return HttpNotFound();
            }
            return View(immigrationService);
        }

        // GET: ImmigrationServices/Create
        public ActionResult Create()
        {
            ViewBag.PermanentResident = new SelectList(db.PermanentResidents, "Id", "Name");
            ViewBag.State = new SelectList(db.States, "Id", "Name");
            ViewBag.Type = new SelectList(db.ImmigrationServiceTypes, "Id", "Name");
            return View();
        }

        // POST: ImmigrationServices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "Id,Title,State,PermanentResident,Fee,Time,Type,CreatedDate,ModifiedDate,Overview,Description,IsOutstanding")] ImmigrationService immigrationService
            , HttpPostedFileBase Base64Image1
            , HttpPostedFileBase Base64Image2
            , HttpPostedFileBase Base64Image3
            , HttpPostedFileBase Base64Image4
            , HttpPostedFileBase Base64Image5)
        {
            immigrationServiceOriginal = null;
            //immigrationService.IsOutstanding = Request["IsOutstanding"] == "on";
            immigrationService.Base64Image1 = getBase64Image(Base64Image1, 1);
            immigrationService.Base64Image2 = getBase64Image(Base64Image2, 2);
            immigrationService.Base64Image3 = getBase64Image(Base64Image3, 3);
            immigrationService.Base64Image4 = getBase64Image(Base64Image4, 4);
            immigrationService.Base64Image5 = getBase64Image(Base64Image5, 5);
            db.ImmigrationServices.Add(immigrationService);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: ImmigrationServices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            immigrationServiceOriginal = db.ImmigrationServices.Find(id);
            if (immigrationServiceOriginal == null)
            {
                return HttpNotFound();
            }
            if (immigrationServiceOriginal.IsOutstanding == null || immigrationServiceOriginal.IsOutstanding == false)
                immigrationServiceOriginal.IsOutstanding = false;

            ViewBag.PermanentResident = new SelectList(db.PermanentResidents, "Id", "Name", immigrationServiceOriginal.PermanentResident);
            ViewBag.State = new SelectList(db.States, "Id", "Name", immigrationServiceOriginal.State);
            ViewBag.Type = new SelectList(db.ImmigrationServiceTypes, "Id", "Name", immigrationServiceOriginal.Type);
            return View(immigrationServiceOriginal);
        }

        // POST: ImmigrationServices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "Id,Title,State,PermanentResident,Fee,Time,Type,CreatedDate,ModifiedDate,Overview,Description,IsOutstanding")] ImmigrationService immigrationService
            , HttpPostedFileBase Base64Image1
            , HttpPostedFileBase Base64Image2
            , HttpPostedFileBase Base64Image3
            , HttpPostedFileBase Base64Image4
            , HttpPostedFileBase Base64Image5)
        {
            immigrationService.Base64Image1 = getBase64Image(Base64Image1, 1);
            immigrationService.Base64Image2 = getBase64Image(Base64Image2, 2);
            immigrationService.Base64Image3 = getBase64Image(Base64Image3, 3);
            immigrationService.Base64Image4 = getBase64Image(Base64Image4, 4);
            immigrationService.Base64Image5 = getBase64Image(Base64Image5, 5);

            db.Entry(immigrationService).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private String getBase64Image(HttpPostedFileBase img, int number)
        {
            if (img == null || img.ContentLength == 0)
            {
                switch (number)
                {
                    case 1:
                        return immigrationServiceOriginal != null ? immigrationServiceOriginal.Base64Image1 : "";
                    case 2:
                        return immigrationServiceOriginal != null ? immigrationServiceOriginal.Base64Image2 : "";
                    case 3:
                        return immigrationServiceOriginal != null ? immigrationServiceOriginal.Base64Image3 : "";
                    case 4:
                        return immigrationServiceOriginal != null ? immigrationServiceOriginal.Base64Image4 : "";
                    case 5:
                        return immigrationServiceOriginal != null ? immigrationServiceOriginal.Base64Image5 : "";
                    default:
                        break;
                }
            }
            byte[] fileInBytes = new byte[img.ContentLength];
            using (BinaryReader theReader = new BinaryReader(img.InputStream))
            {
                fileInBytes = theReader.ReadBytes(img.ContentLength);
            }
            return String.Format("data:{0};base64,{1}", img.ContentType, Convert.ToBase64String(fileInBytes));
        }

        // GET: ImmigrationServices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImmigrationService immigrationService = db.ImmigrationServices.Find(id);
            if (immigrationService == null)
            {
                return HttpNotFound();
            }
            return View(immigrationService);
        }

        // POST: ImmigrationServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ImmigrationService immigrationService = db.ImmigrationServices.Find(id);
            db.ImmigrationServices.Remove(immigrationService);
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
