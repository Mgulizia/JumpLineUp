using System.Linq;
using System.Web.Mvc;
using JumpLineUp.Models;
using JumpLineUp.ViewModels.OtherContact;

namespace JumpLineUp.Controllers
{
    public class OtherContactController : Controller
    {
        private ApplicationDbContext _context;

        public OtherContactController()
        {
            _context = new ApplicationDbContext();
        }



        //------------------------------ View List of Guardian ------------------------------------------------------------------------------
        // GET: Guardian
        public ActionResult Index()
        {
            var otherContacts = _context.OtherContacts.ToList();
            var viewModel = new OtherContactIndexViewModel() {OtherContacts = otherContacts};
            return View("Index", viewModel);
        }


        //------------------------------ Create New Guardian ------------------------------------------------------------------------------
        // GET: Guardian/Create/
        [Authorize(Roles = RoleName.CanManageGuardians)]
        public ActionResult Create()
        {
            var otherContact = new OtherContact();
            otherContact.IsEnabled = true;
            var viewModel = new OtherContactCrudViewModel() {OtherContact = otherContact};
            
            return View("OtherContactForm",viewModel);
        }


        //------------------------------ Edit Guardian ------------------------------------------------------------------------------
        // GET: Guardian/Edit
        [Authorize(Roles = RoleName.CanManageGuardians)]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var otherContact = _context.OtherContacts.SingleOrDefault(c => c.Id == id);
            if (otherContact == null)
                return HttpNotFound();

            var viewModel = new OtherContactCrudViewModel() {OtherContact = otherContact };
            return View("OtherContactForm", viewModel);
        }


        //------------------------------ Save Guardian ------------------------------------------------------------------------------
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageGuardians)]
        public ActionResult Save(OtherContactCrudViewModel model)
        {
            OtherContact contactInDb;

            if (model.OtherContact.Id == 0)
            {
                contactInDb = new OtherContact();
                _context.OtherContacts.Add(contactInDb);
            }
            else
            {
                contactInDb = _context.OtherContacts.Single(c => c.Id == model.OtherContact.Id);
            }

            if (!ModelState.IsValid)
                return View("OtherContactForm", model);

            contactInDb.FirstName = model.OtherContact.FirstName;
            contactInDb.LastName = model.OtherContact.LastName;
            contactInDb.Street1 = model.OtherContact.Street1;
            contactInDb.Street2 = model.OtherContact.Street2;
            contactInDb.City = model.OtherContact.City;
            contactInDb.State = model.OtherContact.State;
            contactInDb.Zip = model.OtherContact.Zip;
            contactInDb.Phone = model.OtherContact.Phone;
            contactInDb.IsEnabled = model.OtherContact.IsEnabled;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}