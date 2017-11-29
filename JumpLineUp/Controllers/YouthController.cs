using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JumpLineUp.Models;
using JumpLineUp.ViewModels;
using JumpLineUp.ViewModels.FosterParents;
using JumpLineUp.ViewModels.ServiceType;
using JumpLineUp.ViewModels.Youth;

namespace JumpLineUp.Controllers
{
    public class YouthController : Controller
    {
        private ApplicationDbContext _context;

        public YouthController()
        {
            _context = new ApplicationDbContext();
        }



        //------------------------------ View List or Individual Youth ------------------------------------------------------------------------------
        // GET: Youth/
        public ActionResult Index()
        {
            var youth = _context.Youths.Include(c => c.RestraintType).ToList();
            var viewModel = new YouthIndexViewModel {Youth = youth};

            return View("Index", viewModel);
        }


        // GET: Youth/{id}
        public ActionResult View(int id)
        {
            var item = _context.Youths.Include(c=>c.RestraintType).SingleOrDefault(c => c.Id == id);

            return View("YouthView", item);
        }


        //------------------------------ Create New Youth ------------------------------------------------------------------------------
        // GET: Youth/New/
        [Authorize(Roles = RoleName.CanManageYouth)]
        public ActionResult Create()
        {
            var youth = new Youth();
            youth.IsEnabled = true;
            youth.BirthDate = DateTime.Now;

            var restraints = _context.RestraintTypes.ToList();
            var viewModel = new YouthCRUDViewModel() {Youth = youth, Restraints = restraints};
            
            return View("YouthForm",viewModel);
        }


        //------------------------------ Edit Youth ------------------------------------------------------------------------------
        // GET: Youth/Edit
        [Authorize(Roles = RoleName.CanManageYouth)]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var youth = _context.Youths.SingleOrDefault(c => c.Id == id);

            if (youth == null)
                return HttpNotFound();

            var restraints = _context.RestraintTypes.ToList();
            var viewModel = new YouthCRUDViewModel() {Youth = youth,Restraints = restraints};

            return View("YouthForm",viewModel);
        }


        //------------------------------ Save Guardian ------------------------------------------------------------------------------
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageYouth)]
        public ActionResult Save(YouthCRUDViewModel model)
        {
            Youth youthInDb;

            if (model.Youth.Id == 0)
            {
                youthInDb = new Youth();
                _context.Youths.Add(youthInDb);
            }
            else
            {
                youthInDb = _context.Youths.Single(c => c.Id == model.Youth.Id);
            }

            if (!ModelState.IsValid)
            {
                model.Restraints = _context.RestraintTypes.ToList();
                return View("YouthForm", model);
            }


            youthInDb.FirstName = model.Youth.FirstName;
            youthInDb.LastName = model.Youth.LastName;
            youthInDb.BirthDate = model.Youth.BirthDate;
            youthInDb.RestraintTypeId = model.Youth.RestraintTypeId;
            youthInDb.YouthComment = model.Youth.YouthComment;
            youthInDb.IsEnabled = model.Youth.IsEnabled;

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}