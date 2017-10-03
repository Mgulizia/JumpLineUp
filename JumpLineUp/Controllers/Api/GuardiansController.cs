using System;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using JumpLineUp.Dtos;
using JumpLineUp.Models;

namespace JumpLineUp.Controllers.Api
{
    public class GuardiansController : ApiController
    {
        private ApplicationDbContext _context;

        public GuardiansController()
        {
            _context = new ApplicationDbContext();
        }



        // GET /api/Guardians
        [HttpGet]
        public IHttpActionResult GetGuardians()
        {
            var guardiansDto = _context.Guardians.ToList().Select(Mapper.Map<Guardian, GuardiansDto>);

            return Ok(guardiansDto);
        }





        // GET /api/Guardians/1
        [HttpGet]
        public IHttpActionResult GetGuardian(int id)
        {
            var guardian = _context.Guardians.SingleOrDefault(c => c.Id == id);

            if (guardian == null)
                return NotFound();

            return Ok(Mapper.Map<Guardian, GuardiansDto>(guardian));
        }


        // POST /api/Guardians
        [HttpPost]
        public IHttpActionResult CreateGuardian(GuardiansDto guardianDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var guardian = Mapper.Map<GuardiansDto, Guardian>(guardianDto);
            _context.Guardians.Add(guardian);
            _context.SaveChanges();

            guardianDto.Id = guardian.Id;

            return Created(new Uri(Request.RequestUri + "/" + guardian.Id), guardianDto);
        }


        // PUT /api/Guardians/1
        [HttpPut]
        public IHttpActionResult UpdateGuardian(int id,GuardiansDto guardiansDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var guardianInDb = _context.Guardians.SingleOrDefault(c => c.Id == id);

            if (guardianInDb == null)
                NotFound();

            Mapper.Map(guardiansDto, guardianInDb);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/Guardians/1
        [HttpDelete]
        public IHttpActionResult ToggleGuardian(int id)
        {
            var guardianInDb = _context.Guardians.SingleOrDefault(c => c.Id == id);

            if (guardianInDb == null)
                return NotFound();

            if (guardianInDb.IsEnabled == true)
                guardianInDb.IsEnabled = false;
            else
                guardianInDb.IsEnabled = true;

            _context.SaveChanges();

            return Ok();
        }


    }

}

