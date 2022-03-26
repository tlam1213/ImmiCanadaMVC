using ImmiCanada.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImmiCanada.Controllers
{
    public class HomeController : BaseController
    {
        private ImmiCanadaEntities db = new ImmiCanadaEntities();
        public ActionResult Index()
        {
            ViewData["OutstandingServices"] = db.ImmigrationServices.Where(i => i.IsOutstanding == true).Take(3).ToList();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult InterestedSection()
        {
            return PartialView();
        }

        public ActionResult NewsSlide()
        {
            ViewData["WorksSlide"] = db.Works.OrderByDescending(i => i.WorkId).Take(8).ToList();
            return PartialView();
        }

        public ActionResult CanadaDeserveToLife()
        {
            return PartialView();
        }
    }
}