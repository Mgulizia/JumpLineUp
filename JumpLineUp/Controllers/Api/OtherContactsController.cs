using System;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using JumpLineUp.Dtos;
using JumpLineUp.Models;

namespace JumpLineUp.Controllers.Api
{
    public class OtherContactsController : ApiController
    {
        private ApplicationDbContext _context;

        public OtherContactsController()
        {
            _context = new ApplicationDbContext();
        }



        // GET /api/OtherContacts
        [HttpGet]
        public IHttpActionResult GetOtherContacts(string query = null)
        {
            var otherContactQuery = _context.OtherContacts.AsQueryable();

            if (!String.IsNullOrWhiteSpace(query))
                otherContactQuery = otherContactQuery
                    .Where(c =>
                        c.FirstName.Contains(query) ||
                        c.LastName.Contains(query))
                    .Where(c=>c.IsEnabled);

            var otherContactDto = otherContactQuery.ToList().Select(Mapper.Map<OtherContact, OtherContactDto>);

            return Ok(otherContactDto);
        }


        // GET /api/OtherContact/1
        [HttpGet]
        public IHttpActionResult GetOtherContact(int id)
        {
            var contact = _context.OtherContacts.SingleOrDefault(c => c.Id == id);

            if (contact == null)
                return NotFound();

            return Ok(Mapper.Map<OtherContact, OtherContactDto>(contact));
        }


        // POST /api/OtherContact
        [HttpPost]
        public IHttpActionResult CreateOtherContact(OtherContactDto otherContactDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var otherContact = Mapper.Map<OtherContactDto, OtherContact>(otherContactDto);
            _context.OtherContacts.Add(otherContact);
            _context.SaveChanges();

            otherContactDto.Id = otherContact.Id;

            return Created(new Uri(Request.RequestUri + "/" + otherContact.Id), otherContactDto);
        }


        // PUT /api/OtherContact/1
        [HttpPut]
        public IHttpActionResult UpdateOtherContact(int id,OtherContactDto otherContactDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var otherContactInDb = _context.OtherContacts.SingleOrDefault(c => c.Id == id);

            if (otherContactInDb == null)
                NotFound();

            Mapper.Map(otherContactDto, otherContactInDb);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/OtherContact/1
        [HttpDelete]
        public IHttpActionResult ToggleOtherContact(int id)
        {
            var otherContactInDb = _context.OtherContacts.SingleOrDefault(c => c.Id == id);

            if (otherContactInDb == null)
                return NotFound();

            if (otherContactInDb.IsEnabled == true)
                otherContactInDb.IsEnabled = false;
            else
                otherContactInDb.IsEnabled = true;

            _context.SaveChanges();

            return Ok();
        }


    }

}

