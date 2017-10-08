using System;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using JumpLineUp.Dtos;
using JumpLineUp.Models;

namespace JumpLineUp.Controllers.Api
{
    public class YouthsController : ApiController
    {
        private ApplicationDbContext _context;

        public YouthsController()
        {
            _context = new ApplicationDbContext();
        }



        // GET /api/Youth
        [HttpGet]
        public IHttpActionResult GetYouths(string query = null)
        {
            var youthQuery = _context.Youths.AsQueryable();

            if (!String.IsNullOrWhiteSpace(query))
                youthQuery = youthQuery
                    .Where(c =>
                        c.FirstName.Contains(query) ||
                        c.LastName.Contains(query));

            var item = youthQuery.ToList().Select(Mapper.Map<Youth, YouthDto>);


            return Ok(item);
        }





        // GET /api/Youth/1
        [HttpGet]
        public IHttpActionResult GetYouth(int id)
        {
            var item = _context.Youths.SingleOrDefault(c => c.Id == id);

            if (item == null)
                return NotFound();

            return Ok(Mapper.Map<Youth, YouthDto>(item));
        }


        // POST /api/Youth
        [HttpPost]
        public IHttpActionResult CreateYouth(YouthDto itemDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var item = Mapper.Map<YouthDto, Youth>(itemDto);
            _context.Youths.Add(item);
            _context.SaveChanges();

            itemDto.Id = item.Id;

            return Created(new Uri(Request.RequestUri + "/" + item.Id), itemDto);
        }


        // PUT /api/Youth/1
        [HttpPut]
        public IHttpActionResult UpdateYouth(int id,YouthDto itemDto)
        {
            if (!ModelState.IsValid)    
                return BadRequest();

            var itemInDb = _context.Youths.SingleOrDefault(c => c.Id == id);

            if (itemInDb == null)
                NotFound();

            Mapper.Map(itemDto, itemInDb);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/Youth/1
        [HttpDelete]
        public IHttpActionResult ToggleYouth(int id)
        {
            var itemInDb = _context.Youths.SingleOrDefault(c => c.Id == id);

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

