using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JumpLineUp.Models;
using JumpLineUp.ViewModels;
using JumpLineUp.ViewModels.BlcsOffice;

namespace JumpLineUp.Controllers
{
    public class BlcsOfficeController : Controller
    {
        private ApplicationDbContext _context;

        public BlcsOfficeController()
        {
            _context = new ApplicationDbContext();
        }



        //------------------------------ View Offices ------------------------------------------------------------------------------
        [Authorize(Roles = RoleName.BasicUser)]
        public ActionResult Index()
        {
            var viewModel = new BlcsOfficeIndexViewModel();
            viewModel.Offices = _context.BlcsOffices.ToList();

            return View(viewModel);
        }


        //------------------------------ Create Offices ------------------------------------------------------------------------------
        [Authorize(Roles = RoleName.CanManageUsers)]
        public ActionResult Create()
        {
            var office = new BlcsOffice();
            office.IsEnabled = true;

            return View("OfficeForm",office);
        }


        //------------------------------ Edit Offices ------------------------------------------------------------------------------
        [Authorize(Roles = RoleName.CanManageUsers)]
        public ActionResult Edit(int id)
        {
            if (id == 0)
                return HttpNotFound();

            var office = _context.BlcsOffices.Single(c => c.Id == id);

            return View("OfficeForm", office);

        }



        //------------------------------ Save Offices ------------------------------------------------------------------------------
        public ActionResult Save(BlcsOffice office)
        {
            if (!ModelState.IsValid)
                return View("OfficeForm", office);

            if (office.Id == 0)
                _context.BlcsOffices.Add(office);
            else
            {
                var officeInDb = _context.BlcsOffices.Single(c => c.Id == office.Id);
                officeInDb.LocationDescription = office.LocationDescription;
                officeInDb.Street1 = office.Street1;
                officeInDb.Street2 = office.Street2;
                officeInDb.City = office.City;
                officeInDb.State = office.State;
                officeInDb.Zip = office.Zip;
                officeInDb.Phone = office.Phone;
                officeInDb.IsEnabled = office.IsEnabled;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "BlcsOffice");
        }

        
    }
}