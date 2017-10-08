using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using JumpLineUp.Dtos;
using JumpLineUp.Models;

namespace JumpLineUp.Controllers.Api
{
    public class ClientFamiliesController : ApiController
    {
        public ApplicationDbContext _context { get; set; }

        public ClientFamiliesController()
        {
            _context = new ApplicationDbContext();
        }


        [HttpGet]
        [Route("api/ClientFamilies")]
        public IHttpActionResult getClientFamilies()
        {



            return Ok("Your princess is in another castle");
        }


        // POST /api/ClientFamilies
        [HttpPost]
        [Route("api/ClientFamilies")]
        public IHttpActionResult Create(ClientFamilyDto dto)
        {

            var newFamily = new ClientFamily();

            newFamily.PrimaryClient = _context.Clients.Single(c => c.Id == dto.primaryKey);

            if (dto.secondaryKey != 0)
            {
                newFamily.SecondaryClient = _context.Clients.Single(c => c.Id == dto.secondaryKey);
            }
        
            newFamily.Youths = _context.Youths.Where(y => dto.selectedyouth.Contains(y.Id)).ToList();
            

            _context.ClientFamilies.Add(newFamily);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + newFamily.Id), newFamily);
        }
    }


}
