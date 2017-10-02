using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JumpLineUp.Models;
using JumpLineUp.ViewModels;
using JumpLineUp.ViewModels.FosterParents;
using JumpLineUp.ViewModels.Guardians;

namespace JumpLineUp.Controllers
{
    public class GuardianController : Controller
    {
        private ApplicationDbContext _context;

        public GuardianController()
        {
            _context = new ApplicationDbContext();
        }



        //------------------------------ View List of Guardian ------------------------------------------------------------------------------
        // GET: Guardian
        public ActionResult Index()
        {
            var guardians = _context.Guardians.ToList();
            var viewModel = new GuardianIndexViewModel {Guardians = guardians};
            return View("Index", viewModel);
        }


        //------------------------------ Create New Guardian ------------------------------------------------------------------------------
        // GET: Guardian/Create/
        [Authorize(Roles = RoleName.CanManageGuardians)]
        public ActionResult Create()
        {
            var guardian = new Guardian();
            guardian.IsEnabled = true;
            var viewModel = new GuardiansCRUDViewModel() {Guardian = guardian};
            
            return View("GuardianForm",viewModel);
        }


        //------------------------------ Edit Guardian ------------------------------------------------------------------------------
        // GET: Guardian/Edit
        [Authorize(Roles = RoleName.CanManageGuardians)]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var guardian = _context.Guardians.SingleOrDefault(c => c.Id == id);
            if (guardian == null)
                return HttpNotFound();

            var viewModel = new GuardiansCRUDViewModel() {Guardian = guardian };
            return View("GuardianForm",viewModel);
        }


        //------------------------------ Save Guardian ------------------------------------------------------------------------------
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageGuardians)]
        public ActionResult Save(GuardiansCRUDViewModel model)
        {
            Guardian guardianInDb;

            if (model.Guardian.Id == 0)
            {
                guardianInDb = new Guardian();
                _context.Guardians.Add(guardianInDb);
            }
            else
            {
                guardianInDb = _context.Guardians.Single(c => c.Id == model.Guardian.Id);
            }

            if (!ModelState.IsValid)
                return View("GuardianForm", model);

            guardianInDb.FirstName = model.Guardian.FirstName;
            guardianInDb.LastName = model.Guardian.LastName;
            guardianInDb.Street1 = model.Guardian.Street1;
            guardianInDb.Street2 = model.Guardian.Street2;
            guardianInDb.City = model.Guardian.City;
            guardianInDb.State = model.Guardian.State;
            guardianInDb.Zip = model.Guardian.Zip;
            guardianInDb.Phone = model.Guardian.Phone;
            guardianInDb.IsEnabled = model.Guardian.IsEnabled;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}