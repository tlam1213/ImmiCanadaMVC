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

        public ActionResult SchoolListOntario()
        {
            return PartialView("SchoolList/Ontario");
        }

        public ActionResult SchoolListALberta()
        {
            return PartialView("SchoolList/Alberta");
        }

        public ActionResult SchoolListBritishColumnbia()
        {
            return PartialView("SchoolList/BritishColumnbia");
        }

        public ActionResult SchoolListSaskatchewan()
        {
            return PartialView("SchoolList/Saskatchewan");
        }

        public ActionResult SchoolListManitoba()
        {
            return PartialView("SchoolList/Manitoba");
        }

        public ActionResult SchoolListNewBrun()
        {
            return PartialView("SchoolList/NewBrun");
        }

        public ActionResult SchoolListNL()
        {
            return PartialView("SchoolList/NL");
        }

        public ActionResult SchoolListNova()
        {
            return PartialView("SchoolList/Nova");
        }

        public ActionResult SchoolListPEI()
        {
            return PartialView("SchoolList/PEI");
        }

        public ActionResult SchoolListQuebec()
        {
            return PartialView("SchoolList/Quebec");
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