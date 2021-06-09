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
    public class ServiceController : BaseController
    {
        private ImmiCanadaEntities db = new ImmiCanadaEntities();

        // GET: Service
        public ActionResult Index()
        {
            ViewData["OutstandingServices"] = db.ImmigrationServices.Where(i => i.IsOutstanding == true).ToList();
            ViewData["MetaData"] = GetMetaData();
            var result = new List<ServiceByType>();
            foreach (var state in db.States.ToList())
            {
                var immigrationServices = db.ImmigrationServices.Where(i => i.State == state.Id).ToList();
                if (immigrationServices.Count() > 0)
                {
                    var obj = new ServiceByType();
                    obj.ImmigrationServiceState = immigrationServices.FirstOrDefault().State1.Name;
                    obj.LstImmigrationServices = immigrationServices;

                    result.Add(obj);
                }
            }
            ViewData["ImmigrationServices"] = result.ToList();
            return View(new ServiceSearchCriteria());
        }

        //POST
        [HttpPost]
        public ActionResult Search(ServiceSearchCriteria criteria)
        {
            ViewData["OutstandingServices"] = db.ImmigrationServices.Where(i => i.IsOutstanding == true).ToList();
            ViewData["MetaData"] = GetMetaData();
            var result = new List<ServiceByType>();

            var immigrationServicesReturned = db.ImmigrationServices.
                Where(i => (
                                 (string.IsNullOrEmpty(criteria.q) || i.Title.Contains(criteria.q))
                              && (criteria.StateId == -1 || i.State == criteria.StateId)
                              && (criteria.ImmigrationServiceTypeId == -1 || i.ImmigrationServiceType.Id == criteria.ImmigrationServiceTypeId)
                           ));

            foreach (var immigrationServiceType in db.ImmigrationServiceTypes.ToList())
            {
                var immigrationServices = immigrationServicesReturned.Where(i => i.Type == immigrationServiceType.Id).ToList();
                if (immigrationServices.Count() > 0)
                {
                    var obj = new ServiceByType();
                    obj.ImmigrationServiceState = immigrationServices.FirstOrDefault().State1.Name;
                    obj.LstImmigrationServices = immigrationServices;

                    result.Add(obj);
                }
            }
            ViewData["ImmigrationServices"] = result.ToList();
            return View("Index", criteria);
        }

        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var immigrationService = db.ImmigrationServices.FirstOrDefault(i => i.Id == id);

            return View(immigrationService);
        }

        private MetaData GetMetaData()
        {
            var result = new MetaData();
            result.States = db.States.ToList();
            result.ImmigrationServiceTypes = db.ImmigrationServiceTypes.ToList();
            return result;
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

    public class ServiceByType
    {
        public string ImmigrationServiceState { get; set; }
        public List<ImmigrationService> LstImmigrationServices { get; set; }
    }

    public class ServiceSearchCriteria
    {
        public string q { get; set; }
        public int StateId { get; set; }
        public int ImmigrationServiceTypeId { get; set; }
    }

    public class MetaData
    {
        //ViewData["States"] = db.States.ToList();
        //    ViewData["ImmigrationServiceTypes"] = db.ImmigrationServiceTypes.ToList();
        public List<State> States { get; set; }
        public List<ImmigrationServiceType> ImmigrationServiceTypes { get; set; }
    }
}
