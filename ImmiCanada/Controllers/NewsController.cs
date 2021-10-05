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
    public class NewsController : Controller
    {
        private ImmiCanadaEntities db = new ImmiCanadaEntities();

        private static News newsOriginal;

        // GET: News
        public ActionResult Index()
        {
            var news = db.News.Include(n => n.Creator1);
            return View(news.ToList());
        }

        // GET: News/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // GET: News/Create
        public ActionResult Create()
        {
            ViewBag.Creator = new SelectList(db.Creators, "Id", "FullName");
            return View();
        }

        // POST: News/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(News news, HttpPostedFileBase Base64Image)
        {
            newsOriginal = null;
            news.Base64Image = getBase64Image(Base64Image);
            news.CreatedDate = DateTime.Now;
            news.ModifiedDate = DateTime.Now;
            db.News.Add(news);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: News/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            newsOriginal = db.News.Find(id);
            if (newsOriginal == null)
            {
                return HttpNotFound();
            }
            if (newsOriginal.IsOutstanding == null || newsOriginal.IsOutstanding == false)
                newsOriginal.IsOutstanding = false;
            ViewBag.Creator = new SelectList(db.Creators, "Id", "FullName", newsOriginal.Creator);
            return View(newsOriginal);
        }

        // POST: News/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(News news, HttpPostedFileBase Base64Image)
        {
            news.Base64Image = getBase64Image(Base64Image);
            news.ModifiedDate = DateTime.Now;
            db.Entry(news).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: News/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // POST: News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            News news = db.News.Find(id);
            db.News.Remove(news);
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
                return newsOriginal != null ? newsOriginal.Base64Image : "";
            }
            byte[] fileInBytes = new byte[img.ContentLength];
            using (System.IO.BinaryReader theReader = new BinaryReader(img.InputStream))
            {
                fileInBytes = theReader.ReadBytes(img.ContentLength);
            }
            return String.Format("data:{0};base64,{1}", img.ContentType, Convert.ToBase64String(fileInBytes));
        }
    }
}
