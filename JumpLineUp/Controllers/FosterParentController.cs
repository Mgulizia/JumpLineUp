using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JumpLineUp.Models;
using JumpLineUp.ViewModels;
using JumpLineUp.ViewModels.FosterParents;

namespace JumpLineUp.Controllers
{
    public class FosterParentController : Controller
    {
        private ApplicationDbContext _context;

        public FosterParentController()
        {
            _context = new ApplicationDbContext();
        }



        //------------------------------ View List of Foster Parents ------------------------------------------------------------------------------
        // GET: FosterParent
        public ActionResult Index()
        {
            var fosterParents = _context.FosterParents.ToList();
            var viewModel = new FosterParentIndexViewModel {FosterParents = fosterParents};
            return View("Index", viewModel);
        }


        //------------------------------ Create New Foster Parents ------------------------------------------------------------------------------
        // GET: FosterParent/Create/
        [Authorize(Roles = RoleName.CanManageFosterParents)]
        public ActionResult Create()
        {
            var fosterParent = new FosterParent();
            fosterParent.IsEnabled = true;
            var viewModel = new FosterParentCRUDViewModel() {FosterParent = fosterParent};
            
            return View("FosterParentForm",viewModel);
        }


        //------------------------------ Edit Foster Parents ------------------------------------------------------------------------------
        // GET: FosterParent/Edit
        [Authorize(Roles = RoleName.CanManageFosterParents)]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var fosterParent = _context.FosterParents.SingleOrDefault(c => c.Id == id);
            if (fosterParent == null)
                return HttpNotFound();

            var viewModel = new FosterParentCRUDViewModel(){FosterParent = fosterParent};
            return View("FosterParentForm",viewModel);
        }
        

        //------------------------------ Save Foster Parents ------------------------------------------------------------------------------
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageFosterParents)]
        public ActionResult Save(FosterParentCRUDViewModel model)
        {
            FosterParent fosterParentInDb;

            if (model.FosterParent.Id == 0)
            {
                fosterParentInDb = new FosterParent();
                _context.FosterParents.Add(fosterParentInDb);
            }
            else
            {
                fosterParentInDb = _context.FosterParents.Single(c => c.Id == model.FosterParent.Id);
            }

            if (!ModelState.IsValid)
                return View("FosterParentForm", model);

            fosterParentInDb.FirstName1 = model.FosterParent.FirstName1;
            fosterParentInDb.LastName1 = model.FosterParent.LastName1;
            fosterParentInDb.Phone1 = model.FosterParent.Phone1;
            fosterParentInDb.FirstName2 = model.FosterParent.FirstName2;
            fosterParentInDb.LastName2 = model.FosterParent.LastName2;
            fosterParentInDb.Phone2 = model.FosterParent.Phone2;
            fosterParentInDb.Street1 = model.FosterParent.Street1;
            fosterParentInDb.Street2 = model.FosterParent.Street2;
            fosterParentInDb.City = model.FosterParent.City;
            fosterParentInDb.State = model.FosterParent.State;
            fosterParentInDb.Zip = model.FosterParent.Zip;
            
            fosterParentInDb.IsEnabled = model.FosterParent.IsEnabled;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}