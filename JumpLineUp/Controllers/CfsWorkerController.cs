using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JumpLineUp.Models;

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
            var cfsWorkers = _context.CfsWorkers;
            //var cfsWorkers = _context.CfsWorkers.Where(i => i.IsActive == true);
            //var disabledCfsWorkers = _context.CfsWorkers.Where(i => i.IsActive == false);

            return View(cfsWorkers);
        }


        //------------------------------ New Item Creation ---------------------------------------------------------------------
        public ActionResult NewCfsWorker()
        {

            return View("CfsWorkerForm");
        }

        //------------------------------ Edit Item ------------------------------------------------------------------------------

        public ActionResult EditCfsWorker(int id)
        {
            var cfsWorker = _context.CfsWorkers.SingleOrDefault(c => c.Id == id);

            if (cfsWorker == null)
                return HttpNotFound();




            return View("CfsWorkerForm", cfsWorker);
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


        public ActionResult DisableCfsWorker(int id)
        {
            var cfsWorker = _context.CfsWorkers.Single(i => i.Id == id);
            cfsWorker.IsActive = false;
            _context.SaveChanges();
            return RedirectToAction("Index", "CfsWorker");

        }
    }
}