using System;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using JumpLineUp.Dtos;
using JumpLineUp.Models;

namespace JumpLineUp.Controllers.Api
{
    public class FosterParentsController : ApiController
    {
        private ApplicationDbContext _context;

        public FosterParentsController()
        {
            _context = new ApplicationDbContext();
        }



        // GET /api/FosterParents
        [HttpGet]
        public IHttpActionResult GetFosterParents(string query = null)
        {
            var fosterParentQuery = _context.FosterParents.AsQueryable();

            if (!String.IsNullOrWhiteSpace(query))
                fosterParentQuery = fosterParentQuery
                    .Where(c =>
                        c.FirstName1.Contains(query) ||
                        c.LastName1.Contains(query) ||
                        c.FirstName2.Contains(query) ||
                        c.LastName2.Contains(query))
                    .Where(c => c.IsEnabled);

            var fosterParentDto = fosterParentQuery.ToList().Select(Mapper.Map<FosterParent, FosterParentDto>);

            return Ok(fosterParentDto);
        }


        // GET /api/FosterParents/1
        [HttpGet]
        public IHttpActionResult GetFosterParent(int id)
        {
            var fosterParent = _context.FosterParents.SingleOrDefault(c => c.Id == id);

            if (fosterParent == null)
                return NotFound();

            return Ok(Mapper.Map<FosterParent, FosterParentDto>(fosterParent));
        }


        // POST /api/FosterParents
        [HttpPost]
        public IHttpActionResult CreateFosterParent(FosterParentDto fosterParentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var fosterParent = Mapper.Map<FosterParentDto, FosterParent>(fosterParentDto);
            _context.FosterParents.Add(fosterParent);
            _context.SaveChanges();

            fosterParentDto.Id = fosterParent.Id;

            return Created(new Uri(Request.RequestUri + "/" + fosterParent.Id), fosterParentDto);
        }

        // PUT /api/FosterParents/1
        [HttpPut]
        public IHttpActionResult UpdateFosterParent(int id, FosterParentDto fosterParentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var fosterParentInDb = _context.FosterParents.SingleOrDefault(c => c.Id == id);

            if (fosterParentInDb == null)
                NotFound();

            Mapper.Map(fosterParentDto, fosterParentInDb);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/fosterParents/1
        [HttpDelete]
        public IHttpActionResult ToggleFosterParent(int id)
        {
            var fosterParentInDb = _context.FosterParents.SingleOrDefault(c => c.Id == id);

            if (fosterParentInDb == null)
                return NotFound();

            if (fosterParentInDb.IsEnabled == true)
                fosterParentInDb.IsEnabled = false;
            else
                fosterParentInDb.IsEnabled = true;

            _context.SaveChanges();

            return Ok();
        }


    }

}

