using System;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using JumpLineUp.Dtos;
using JumpLineUp.Models;

namespace JumpLineUp.Controllers.Api
{
    public class YouthInServicesController : ApiController
    {
        private ApplicationDbContext _context;

        public YouthInServicesController()
        {
            _context = new ApplicationDbContext();
        }



        // GET /api/YouthInServices
        [HttpGet]
        public IHttpActionResult GetYouthInServices()
        {
            var item = _context.YouthInService.ToList().Select(Mapper.Map<YouthInService, YouthInServiceDto>);

            return Ok(item);
        }





        // GET /api/YouthInServices/1
        [HttpGet]
        public IHttpActionResult GetYouthInServices(int id)
        {
            var item = _context.YouthInService.SingleOrDefault(c => c.Id == id);

            if (item == null)
                return NotFound();

            return Ok(Mapper.Map<YouthInService, YouthInServiceDto>(item));
        }


        // POST /api/YouthInServices
        [HttpPost]
        public IHttpActionResult CreateYouthInServices(YouthInServiceDto itemDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var item = Mapper.Map<YouthInServiceDto, YouthInService>(itemDto);
            _context.YouthInService.Add(item);
            _context.SaveChanges();

            itemDto.Id = item.Id;

            return Created(new Uri(Request.RequestUri + "/" + item.Id), itemDto);
        }


        // PUT /api/YouthInServices/1
        [HttpPut]
        public IHttpActionResult UpdateYouthInServices(int id,YouthInService itemDto)
        {
            if (!ModelState.IsValid)    
                return BadRequest();

            var itemInDb = _context.YouthInService.SingleOrDefault(c => c.Id == id);

            if (itemInDb == null)
                NotFound();

            Mapper.Map(itemDto, itemInDb);

            _context.SaveChanges();

            return Ok();
        }

    }

}

