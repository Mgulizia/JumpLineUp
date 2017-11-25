using System;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using JumpLineUp.Dtos;
using JumpLineUp.Models;

namespace JumpLineUp.Controllers.Api
{
    public class SupportServicesController : ApiController
    {
        private ApplicationDbContext _context;

        public SupportServicesController()
        {
            _context = new ApplicationDbContext();
        }



        // GET /api/SupportServices
        [HttpGet]
        public IHttpActionResult GetSupportServices()
        {
            var item = _context.SupportServices.ToList().Select(Mapper.Map<SupportService, SupportServiceDto>);

            return Ok(item);
        }





        // GET /api/SupportServices/1
        [HttpGet]
        public IHttpActionResult GetSupportService(int id)
        {
            var item = _context.SupportServices.SingleOrDefault(c => c.Id == id);

            if (item == null)
                return NotFound();

            return Ok(Mapper.Map<SupportService, SupportServiceDto>(item));
        }


        // POST /api/SupportServices
        [HttpPost]
        public IHttpActionResult CreateSupportService(SupportServiceDto itemDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (itemDto.FosterParentId == 0)
                itemDto.FosterParentId = null;

            var item = Mapper.Map<SupportServiceDto, SupportService>(itemDto);

            foreach (var youth in item.YouthId)
            {
                item.Youth.Add(_context.Youths.SingleOrDefault(c=>c.Id == youth));
            }
            foreach (var others in item.OtherContactId)
            {
                item.OtherContacts.Add(_context.OtherContacts.SingleOrDefault(c=>c.Id == others));
            }

            _context.SupportServices.Add(item);
            _context.SaveChanges();

            itemDto.Id = item.Id;

            return Created(new Uri(Request.RequestUri + "/" + item.Id), itemDto);
        }


        // PUT /api/SupportServices/1
        [HttpPut]
        public IHttpActionResult UpdateSupportService(int id,SupportServiceDto itemDto)
        {
            if (!ModelState.IsValid)    
                return BadRequest();

            var itemInDb = _context.SupportServices.SingleOrDefault(c => c.Id == id);

            if (itemInDb == null)
                NotFound();

            Mapper.Map(itemDto, itemInDb);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/SupportServices/1
        [HttpDelete]
        public IHttpActionResult ToggleSupportService(int id)
        {
            var itemInDb = _context.SupportServices.SingleOrDefault(c => c.Id == id);

            if (itemInDb == null)
                return NotFound();

            if (itemInDb.OnHold == true)
                itemInDb.OnHold = false;
            else
                itemInDb.OnHold = true;

            _context.SaveChanges();

            return Ok();
        }


    }

}

