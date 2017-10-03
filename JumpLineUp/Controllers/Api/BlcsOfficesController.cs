using System;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using JumpLineUp.Dtos;
using JumpLineUp.Models;

namespace JumpLineUp.Controllers.Api
{
    public class BlcsOfficesController : ApiController
    {
        private ApplicationDbContext _context;

        public BlcsOfficesController()
        {
            _context = new ApplicationDbContext();
        }



        // GET /api/BlcsOffices
        [HttpGet]
        public IHttpActionResult GetBlcsOffices()
        {
            var item = _context.BlcsOffices.ToList().Select(Mapper.Map<BlcsOffice, BlcsOfficeDto>);

            return Ok(item);
        }





        // GET /api/BlcsOffices/1
        [HttpGet]
        public IHttpActionResult GetBlcsOffices(int id)
        {
            var item = _context.BlcsOffices.SingleOrDefault(c => c.Id == id);

            if (item == null)
                return NotFound();

            return Ok(Mapper.Map<BlcsOffice, BlcsOfficeDto>(item));
        }


        // POST /api/BlcsOffices
        [HttpPost]
        public IHttpActionResult CreateBlcsOffices(BlcsOfficeDto itemDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var item = Mapper.Map<BlcsOfficeDto, BlcsOffice>(itemDto);
            _context.BlcsOffices.Add(item);
            _context.SaveChanges();

            itemDto.Id = item.Id;

            return Created(new Uri(Request.RequestUri + "/" + item.Id), itemDto);
        }


        // PUT /api/BlcsOffices/1
        [HttpPut]
        public IHttpActionResult UpdateBlcsOffices(int id,BlcsOfficeDto itemDto)
        {
            if (!ModelState.IsValid)    
                return BadRequest();

            var itemInDb = _context.BlcsOffices.SingleOrDefault(c => c.Id == id);

            if (itemInDb == null)
                NotFound();

            Mapper.Map(itemDto, itemInDb);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/BlcsOffices/1
        [HttpDelete]
        public IHttpActionResult ToggleBlcsOffices(int id)
        {
            var itemInDb = _context.BlcsOffices.SingleOrDefault(c => c.Id == id);

            if (itemInDb == null)
                return NotFound();

            if (itemInDb.IsEnabled == true)
                itemInDb.IsEnabled = false;
            else
                itemInDb.IsEnabled = true;

            _context.SaveChanges();

            return Ok();
        }


    }

}

