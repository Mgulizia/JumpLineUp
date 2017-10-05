using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JumpLineUp.Models;
using JumpLineUp.ViewModels;
using JumpLineUp.ViewModels.Client;
using JumpLineUp.ViewModels.FosterParents;
using JumpLineUp.ViewModels.ServiceType;

namespace JumpLineUp.Controllers
{
    public class ClientController : Controller
    {
        private ApplicationDbContext _context;

        public ClientController()
        {
            _context = new ApplicationDbContext();
        }



        //------------------------------ View List of Guardian ------------------------------------------------------------------------------
        // GET: Guardian
        public ActionResult Index()
        {
            var guardians = _context.Clients.ToList();
            var viewModel = new ClientIndexViewModel {Guardians = guardians};
            return View("Index", viewModel);
        }


        //------------------------------ Create New Guardian ------------------------------------------------------------------------------
        // GET: Guardian/Create/
        [Authorize(Roles = RoleName.CanManageGuardians)]
        public ActionResult Create()
        {
            var guardian = new Client();
            guardian.IsEnabled = true;
            var viewModel = new ClientCrudViewModel() {Guardian = guardian};
            
            return View("ClientForm",viewModel);
        }


        //------------------------------ Edit Guardian ------------------------------------------------------------------------------
        // GET: Guardian/Edit
        [Authorize(Roles = RoleName.CanManageGuardians)]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var guardian = _context.Clients.SingleOrDefault(c => c.Id == id);
            if (guardian == null)
                return HttpNotFound();

            var viewModel = new ClientCrudViewModel() {Guardian = guardian };
            return View("ClientForm", viewModel);
        }


        //------------------------------ Save Guardian ------------------------------------------------------------------------------
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageGuardians)]
        public ActionResult Save(ClientCrudViewModel model)
        {
            Client guardianInDb;

            if (model.Guardian.Id == 0)
            {
                guardianInDb = new Client();
                _context.Clients.Add(guardianInDb);
            }
            else
            {
                guardianInDb = _context.Clients.Single(c => c.Id == model.Guardian.Id);
            }

            if (!ModelState.IsValid)
                return View("ClientForm", model);

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