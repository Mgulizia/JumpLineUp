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

        //------------------------------ View List of / individual Support Services ------------------------------------------------------------
        public ActionResult Index()
        {
            CheckHoldStatus();
            var needsScheduling = _context.SupportServices
                .Include(c => c.ServiceType)
                .Include(c => c.Client)
                .Include(c => c.CfsWorker)
                .Where(c=> c.OnHold == false)
                .Where(c => c.StatusId == 1)
                .ToList();

            var expiredServices = _context.SupportServices
                .Include(c => c.ServiceType)
                .Include(c => c.Client)
                .Include(c => c.CfsWorker)
                .Where(c => c.OnHold == true)
                .ToList();

            var viewModel = new SupportServiceIndexViewModel
            {
                NeedsScheduling = needsScheduling,
                ExpiredServices = expiredServices
            };

            return View("index", viewModel);
        }

        public ActionResult View(int id)
        {
            var item = _context.SupportServices
                .Include(c => c.ServiceType)
                .Include(c => c.ServiceArea)
                .Include(c => c.Client)
                .Include(c => c.Youth)
                .Include(c => c.Youth.Select(y => y.RestraintType))
                .Include(c => c.CfsWorker)
                .Include(c => c.OtherContacts)
                .Include(c => c.FosterParent)
                .SingleOrDefault(c => c.Id == id);

            return View("SupportServicesView", item);
        }


        //------------------------------ Edit and Processing of Support Service ------------------------------------------------------------------------------
        public ActionResult Schedule(int id)
        {
            var serviceSchedule = new ServiceSchedule
            {
                ScheduleStartDate = DateTime.Today
            };

            var service = _context.SupportServices
                .Include(c => c.Client)
                .Include(c => c.FosterParent)
                .SingleOrDefault(c => c.Id == id);



            var vm = new ServiceScheduleCreateViewModel
            {
                ServiceSchedule = serviceSchedule,
                SupportService = service,
                BlcsOffices = _context.BlcsOffices.ToList()
                
            };

            return View("SupportServicesSchedule",vm);
        } 
        

        //------------------------------ Save new Support Service ------------------------------------------------------------------------------
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





        //------------------------------ Misc Support Service Methods ------------------------------------------------------------------------------
        private void CheckHoldStatus()
        {
            var currentServices = _context.SupportServices.ToList();

            foreach (var service in currentServices)
            {
                service.CheckHoldStatus();
            }
        }





    }
}