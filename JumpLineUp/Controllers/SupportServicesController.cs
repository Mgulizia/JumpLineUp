using System;
using System.Collections.Generic;
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