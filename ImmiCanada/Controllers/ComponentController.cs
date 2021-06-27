using ImmiCanada.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImmiCanada.Controllers
{
    public class ComponentController : Controller
    {
        private ImmiCanadaEntities db = new ImmiCanadaEntities();
        // GET: Component
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Works(string ServiceId)
        {
            return PartialView();
        }
    }
}