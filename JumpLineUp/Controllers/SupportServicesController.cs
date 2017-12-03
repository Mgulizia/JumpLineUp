using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http.Results;
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

            var needsAssigning = _context.SupportServices
                .Include(c => c.ServiceType)
                .Include(c => c.Client)
                .Include(c => c.CfsWorker)
                .Where(c => c.OnHold == false)
                .Where(c => c.StatusId == 2)
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
                NeedsAssigning = needsAssigning,
                ExpiredServices = expiredServices
            };

            return View("index", viewModel);
        }

        public ActionResult View(int id)
        {
            var service = _context.SupportServices
                .Include(c => c.ServiceType)
                .Include(c => c.ServiceArea)
                .Include(c => c.Client)
                .Include(c => c.Youth)
                .Include(c => c.Youth.Select(y => y.RestraintType))
                .Include(c => c.CfsWorker)
                .Include(c => c.OtherContacts)
                .Include(c => c.FosterParent)
                .SingleOrDefault(c => c.Id == id);

            var schedule = _context.ServiceSchedules
                .Where(c => c.SupportServiceId == service.Id)
                .Where(c => c.CurrentSchedule == true)
                .OrderBy(c=>c.ScheduleEndDate)
                .ToList();
                

            var model = new SupportServiceDetailViewModel()
            {
                SupportServices = service,
                ServiceSchedule = schedule.First()

            };

            return View("SupportServicesView", model);
        }


        //------------------------------ Edit and Processing of Support Service ------------------------------------------------------------------------------
        public ActionResult Schedule(int id)
        {

            var service = _context.SupportServices
                .Include(c => c.Client)
                .Include(c => c.FosterParent)
                .SingleOrDefault(c => c.Id == id);

            if (service == null)
            {
                return HttpNotFound();
            }

            var serviceSchedule = new ServiceSchedule();


            if (service.ServiceStart != null)
                serviceSchedule.ScheduleStartDate = service.ServiceStart.Value;
            

            if (service.ServiceStop != null)
                serviceSchedule.ScheduleEndDate = service.ServiceStop.Value;


            if (service.Id != 0)
                serviceSchedule.SupportServiceId = service.Id;
            else
            {
                return HttpNotFound();
            }

            var vm = new ServiceScheduleCreateViewModel
            {
                ServiceSchedule = serviceSchedule,
                SupportService = service,
                BlcsOffices = _context.BlcsOffices.ToList()
                
            };

            return View("SupportServicesSchedule",vm);
        } 
        

        //------------------------------ Save new Support Service / Schedule ----------------------------------------------------------------------
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

        public ActionResult SaveSchedule(ServiceScheduleCreateViewModel model)
        {
            ServiceSchedule modelInDb;

            if (model.ServiceSchedule.Id == 0)
            {
                modelInDb = new ServiceSchedule();
                _context.ServiceSchedules.Add(modelInDb);
            }
            else
            {
                modelInDb = _context.ServiceSchedules.Single(c => c.Id == model.ServiceSchedule.Id);
            }

            var oldSchedules = _context.ServiceSchedules
                    .Where(c => c.CurrentSchedule == true && c.SupportServiceId == model.ServiceSchedule.SupportServiceId)
                    .ToList();

            var service = _context.SupportServices.SingleOrDefault(c => c.Id == model.ServiceSchedule.SupportServiceId);
            
            if (!ModelState.IsValid)
                return View("SupportServicesSchedule", model);

            modelInDb.ScheduleStartDate = model.ServiceSchedule.ScheduleStartDate;
            modelInDb.ScheduleEndDate = model.ServiceSchedule.ScheduleEndDate;
            modelInDb.PickupDetails = model.ServiceSchedule.PickupDetails;
            modelInDb.VisitationLocation = model.ServiceSchedule.VisitationLocation;
            modelInDb.DropOffLocation = model.ServiceSchedule.DropOffLocation;
            modelInDb.Restrictions = model.ServiceSchedule.Restrictions;
            modelInDb.SupportServiceId = model.ServiceSchedule.SupportServiceId;
            modelInDb.CurrentSchedule = true;

            modelInDb.Sunday = model.ServiceSchedule.Sunday;
            modelInDb.SunStartTime = model.ServiceSchedule.SunStartTime;
            modelInDb.SunDuration = model.ServiceSchedule.SunDuration;

            modelInDb.Monday = model.ServiceSchedule.Monday;
            modelInDb.MonStartTime = model.ServiceSchedule.MonStartTime;
            modelInDb.MonDuration = model.ServiceSchedule.MonDuration;

            modelInDb.Tuesday = model.ServiceSchedule.Tuesday;
            modelInDb.TueStartTime = model.ServiceSchedule.TueStartTime;
            modelInDb.TueDuration = model.ServiceSchedule.TueDuration;

            modelInDb.Wednesday = model.ServiceSchedule.Wednesday;
            modelInDb.WedStartTime = model.ServiceSchedule.WedStartTime;
            modelInDb.WedDuration = model.ServiceSchedule.WedDuration;

            modelInDb.Thursday = model.ServiceSchedule.Thursday;
            modelInDb.ThurStartTime = model.ServiceSchedule.ThurStartTime;
            modelInDb.ThurDuration = model.ServiceSchedule.ThurDuration;

            modelInDb.Friday = model.ServiceSchedule.Friday;
            modelInDb.FriStartTime = model.ServiceSchedule.FriStartTime;
            modelInDb.FriDuration = model.ServiceSchedule.FriDuration;

            modelInDb.Saturday = model.ServiceSchedule.Saturday;
            modelInDb.SatStartTime = model.ServiceSchedule.SatStartTime;
            modelInDb.SatDuration = model.ServiceSchedule.SatDuration;

            foreach (var schedule in oldSchedules)
                schedule.CurrentSchedule = false;

            if(service != null)
                service.StatusId = SupportStatusNames.NeedsAssignment;
            

            _context.SaveChanges();

            return RedirectToAction("Index", "SupportServices");
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