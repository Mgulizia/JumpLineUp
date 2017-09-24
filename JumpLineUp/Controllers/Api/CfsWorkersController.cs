using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

using System.Web.Http;

using JumpLineUp.Models;

namespace JumpLineUp.Controllers.Api
{
    public class CfsWorkersController : ApiController
    {
        private ApplicationDbContext _context;

        public CfsWorkersController()
        {
            _context = new ApplicationDbContext();
        }



        // GET /api/CfsWorkers
        public IEnumerable<CfsWorker> GetCfsWorkers()
        {
            return _context.CfsWorkers.ToList();
        }


        // GET /api/CfsWorkers/1
        public CfsWorker GetCfsWorker(int id)
        {
            var cfsWorker = _context.CfsWorkers.SingleOrDefault(c => c.Id == id);

            if(cfsWorker == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return cfsWorker;
        }


        // POST /api/CfsWorkers
        [HttpPost]
        public CfsWorker CreateCfsWorker(CfsWorker cfsWorker)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.CfsWorkers.Add(cfsWorker);
            _context.SaveChanges();

            return cfsWorker;
        }

        // PUT /api/CfsWorkers/1
        [HttpPut]
        public void UpdateCfsWorker(int id, CfsWorker cfsWorker)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var cfsWorkerInDb = _context.CfsWorkers.SingleOrDefault(c => c.Id == id);

            if(cfsWorkerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            cfsWorkerInDb.FirstName = cfsWorker.FirstName;
            cfsWorkerInDb.LastName = cfsWorker.LastName;
            cfsWorkerInDb.Phone = cfsWorker.Phone;
            cfsWorkerInDb.Email = cfsWorker.Email;
            cfsWorkerInDb.OfficeLocation = cfsWorker.OfficeLocation;
            cfsWorkerInDb.IsActive = cfsWorker.IsActive;

            _context.SaveChanges();
        }

        // DELETE /api/CfsWorker/1
        [HttpDelete]
        public void ToggleCfsWorker(int id)
        {
            var cfsWorkerInDb = _context.CfsWorkers.SingleOrDefault(c => c.Id == id);

            if (cfsWorkerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            if (cfsWorkerInDb.IsActive == true)
                cfsWorkerInDb.IsActive = false;
            else
                cfsWorkerInDb.IsActive = true;

            _context.SaveChanges();
        }


    }
}
