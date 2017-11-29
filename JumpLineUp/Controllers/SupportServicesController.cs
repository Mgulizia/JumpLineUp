using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JumpLineUp.Models;
using JumpLineUp.ViewModels.SupportServices;

namespace JumpLineUp.Controllers
{
    public class SupportServicesController : Controller
    {
        public ApplicationDbContext _context { get; set; }

        public SupportServicesController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var newSupportServices = _context.SupportServices
                .Include(c=>c.ServiceType)
                .Include(c=>c.Client)
                .Include(c=>c.CfsWorker)
                .Include(c=>c.Youth)
                .Include(c=>c.OtherContacts)
                .ToList();

            var viewModel = new SupportServiceIndexViewModel
            {
                NewSupportServices = newSupportServices
            };

            return View("index", viewModel);
        }

       
        public ActionResult Create()
        {
            var viewModel = new SupportServicesViewModel
            {
                SupportServices = new SupportService(),
                ServiceAreas = _context.ServiceAreas.Where(m => m.CurrentlyServing == true).ToList(),
                ServiceTypes = _context.ServiceTypes.Where(m => m.CurrentService == true).ToList(),
                RestraintTypes = _context.RestraintTypes.ToList()
            };

            return View("SupportServiceCreate", viewModel );
        }
    }
}