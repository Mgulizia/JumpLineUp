using System.Linq;
using System.Web.Mvc;
using JumpLineUp.Models;
using JumpLineUp.ViewModels.ServiceType;


namespace JumpLineUp.Controllers
{
    public class ServiceTypeController : Controller
    {
        private ApplicationDbContext _context;

        public ServiceTypeController()
        {
            _context = new ApplicationDbContext();
        }



        //------------------------------ View List of Service Types ------------------------------------------------------------------------------
        // GET: ServiceType/
        public ActionResult Index()
        {
            var serviceTypes = _context.ServiceTypes.ToList();
            var viewModel = new ServiceTypeIndexViewModel(){ServiceTypes = serviceTypes};

            return View("Index", viewModel);
        }


        //------------------------------ Create New Service Types ------------------------------------------------------------------------------
        // GET: ServiceType/New/
        [Authorize(Roles = RoleName.CanManageYouth)]
        public ActionResult Create()
        {
            var serviceType = new ServiceType();
            serviceType.CurrentService = true;

            var viewModel = new ServiceTypeCRUDViewModel() {ServiceType = serviceType};
            
            return View("ServiceTypeForm",viewModel);
        }


        //------------------------------ Edit Service Types ------------------------------------------------------------------------------
        // GET: ServiceType/Edit
        [Authorize(Roles = RoleName.CanManageYouth)]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var serviceType = _context.ServiceTypes.SingleOrDefault(c => c.Id == id);

            if (serviceType == null)
                return HttpNotFound();

            var viewModel = new ServiceTypeCRUDViewModel() {ServiceType = serviceType};

            return View("ServiceTypeForm", viewModel);
        }


        //------------------------------ Save Service Types ------------------------------------------------------------------------------
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageYouth)]
        public ActionResult Save(ServiceTypeCRUDViewModel model)
        {
            ServiceType serviceTypeInDb;

            if (model.ServiceType.Id == 0)
            {
                serviceTypeInDb = new ServiceType();
                _context.ServiceTypes.Add(serviceTypeInDb);
            }
            else
            {
                serviceTypeInDb = _context.ServiceTypes.Single(c => c.Id == model.ServiceType.Id);
            }

            if (!ModelState.IsValid)
            {
                return View("ServiceTypeForm", model);
            }


            serviceTypeInDb.ServiceAbbrieviation = model.ServiceType.ServiceAbbrieviation;
            serviceTypeInDb.ServiceName = model.ServiceType.ServiceName;
            serviceTypeInDb.ServiceCode = model.ServiceType.ServiceCode;
            serviceTypeInDb.CurrentService = model.ServiceType.CurrentService;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}