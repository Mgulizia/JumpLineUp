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
        public IHttpActionResult GetCfsWorkers()
        {
            var customerDtos = _context.CfsWorkers.ToList().Select(Mapper.Map<CfsWorker, CfsWorkerDto>);

            return Ok(customerDtos);
        }


        // GET /api/CfsWorkers/1
        public IHttpActionResult GetCfsWorker(int id)
        {
            var cfsWorker = _context.CfsWorkers.SingleOrDefault(c => c.Id == id);

            if (cfsWorker == null)
                return NotFound();

            return Ok(Mapper.Map<CfsWorker,CfsWorkerDto>(cfsWorker));
        }


        // POST /api/CfsWorkers
        [HttpPost]
        public IHttpActionResult CreateCfsWorker(CfsWorkerDto cfsWorkerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var cfsWorker = Mapper.Map<CfsWorkerDto, CfsWorker>(cfsWorkerDto);
            _context.CfsWorkers.Add(cfsWorker);
            _context.SaveChanges();

            cfsWorkerDto.Id = cfsWorker.Id;

            return Created(new Uri(Request.RequestUri + "/" + cfsWorker.Id), cfsWorkerDto);
        }

        // PUT /api/CfsWorkers/1
        [HttpPut]
        public IHttpActionResult UpdateCfsWorker(int id, CfsWorkerDto cfsWorkerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var cfsWorkerInDb = _context.CfsWorkers.SingleOrDefault(c => c.Id == id);

            if (cfsWorkerInDb == null)
                NotFound();

            Mapper.Map(cfsWorkerDto, cfsWorkerInDb);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/CfsWorker/1
        [HttpDelete]
        public IHttpActionResult ToggleCfsWorker(int id)
        {
            var cfsWorkerInDb = _context.CfsWorkers.SingleOrDefault(c => c.Id == id);

            if (cfsWorkerInDb == null)
                return NotFound();

            if (cfsWorkerInDb.IsActive == true)
                cfsWorkerInDb.IsActive = false;
            else
                cfsWorkerInDb.IsActive = true;

            _context.SaveChanges();

            return Ok();
        }


    }
}
