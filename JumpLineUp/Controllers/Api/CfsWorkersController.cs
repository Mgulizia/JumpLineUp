using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using AutoMapper;
using JumpLineUp.Dtos;
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
        public IEnumerable<CfsWorkerDto> GetCfsWorkers()
        {
            return _context.CfsWorkers.ToList().Select(Mapper.Map<CfsWorker,CfsWorkerDto>);
        }


        // GET /api/CfsWorkers/1
        public CfsWorkerDto GetCfsWorker(int id)
        {
            var cfsWorker = _context.CfsWorkers.SingleOrDefault(c => c.Id == id);

            if(cfsWorker == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Mapper.Map<CfsWorker,CfsWorkerDto>(cfsWorker);
        }


        // POST /api/CfsWorkers
        [HttpPost]
        public CfsWorkerDto CreateCfsWorker(CfsWorkerDto cfsWorkerDto)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var cfsWorker = Mapper.Map<CfsWorkerDto, CfsWorker>(cfsWorkerDto);
            _context.CfsWorkers.Add(cfsWorker);
            _context.SaveChanges();

            cfsWorkerDto.Id = cfsWorker.Id;
            return cfsWorkerDto;
        }

        // PUT /api/CfsWorkers/1
        [HttpPut]
        public void UpdateCfsWorker(int id, CfsWorkerDto cfsWorkerDto)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var cfsWorkerInDb = _context.CfsWorkers.SingleOrDefault(c => c.Id == id);

            if(cfsWorkerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(cfsWorkerDto, cfsWorkerInDb);

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
