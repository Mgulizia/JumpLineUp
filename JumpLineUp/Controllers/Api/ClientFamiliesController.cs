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
            var primary = _context.Clients.Single(c => c.Id == dto.primaryKey);

            var secondary = _context.Clients.Single(c => c.Id == dto.secondaryKey);

            var youths = _context.Youths.Where(y => dto.selectedyouth.Contains(y.Id)).ToList();

            var newFamily = new ClientFamily()
            {
                PrimaryClient = primary,
                SecondaryClient = secondary,
                Youths = youths

            };

            _context.ClientFamilies.Add(newFamily);


            return Created(new Uri(Request.RequestUri + "/" + newFamily.Id), newFamily);
        }
    }


}
