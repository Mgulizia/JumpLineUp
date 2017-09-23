using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JumpLineUp.Models;
using JumpLineUp.ViewModels.Cfs;

namespace JumpLineUp.Controllers
{
    public class CfsWorkerController : Controller
    {

        //------------------------------ Database Setup -----------------------------------------------------------------------
        private ApplicationDbContext _context;

        public CfsWorkerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        //------------------------------ View Models ---------------------------------------------------------------------------
        public ViewResult Index()
            {
            //create list of CFS Workers
            //var cfsWorkers = _context.CfsWorkers;
            var enabled = _context.CfsWorkers.Where(i => i.IsActive == true).ToList();
            var disabled = _context.CfsWorkers.Where(i => i.IsActive == false).ToList();

            //create ViewModel
            var ViewModel = new CfsIndexViewModel
            {
                EnabledCfsWorkers = enabled,
                DisabledCfsWorkers = disabled
            };
            


            return View(ViewModel);
        }


        //------------------------------ New Item Creation ---------------------------------------------------------------------
        public ActionResult NewCfsWorker()
        {

            return View("CfsWorkerForm");
        }

//------------------------------ Edit Item ------------------------------------------------------------------------------
        //edit cfs worker
        public ActionResult EditCfsWorker(int id)
        {
            var cfsWorker = _context.CfsWorkers.SingleOrDefault(c => c.Id == id);

            if (cfsWorker == null)
                return HttpNotFound();

            return View("CfsWorkerForm", cfsWorker);
        }

        //Toggle a CFS IsActive (true <> False)
        public ActionResult ToggleCfsActive(int id)
        {
            var cfsWorker = _context.CfsWorkers.Single(i => i.Id == id);

            if (cfsWorker.IsActive == true)
                cfsWorker.IsActive = false;
            else
                cfsWorker.IsActive = true;

            _context.SaveChanges();

            return RedirectToAction("Index", "CfsWorker");
        }

        //------------------------------ Update Item -------------------------------------------------------------------------------
        [HttpPost]
        public ActionResult Save(CfsWorker cfsWorker)
        {
            if (cfsWorker.Id == 0)
            {
                _context.CfsWorkers.Add(cfsWorker);
            }
            else
            {
                var cfsWorkerInDb = _context.CfsWorkers.Single(c => c.Id == cfsWorker.Id);

                cfsWorkerInDb.FirstName = cfsWorker.FirstName;
                cfsWorkerInDb.LastName = cfsWorker.LastName;
                cfsWorkerInDb.Phone = cfsWorker.Phone;
                cfsWorkerInDb.Email = cfsWorker.Email;
                cfsWorkerInDb.OfficeLocation = cfsWorker.OfficeLocation;
                cfsWorkerInDb.IsActive = cfsWorker.IsActive;
               
            } 
            _context.SaveChanges();
            return RedirectToAction("Index", "CfsWorker");
        }


       
    }
}