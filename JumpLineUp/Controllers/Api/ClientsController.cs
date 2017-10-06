using System;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using JumpLineUp.Dtos;
using JumpLineUp.Models;

namespace JumpLineUp.Controllers.Api
{
    public class ClientsController : ApiController
    {
        private ApplicationDbContext _context;

        public ClientsController()
        {
            _context = new ApplicationDbContext();
        }



        // GET /api/Clients
        [HttpGet]
        public IHttpActionResult GetClients(string query = null)
        {
            var clientsQuery = _context.Clients.AsQueryable();

            if (!String.IsNullOrWhiteSpace(query))
                clientsQuery = clientsQuery
                    .Where( c =>
                    c.FirstName.Contains(query) ||
                    c.LastName.Contains(query) ||
                    c.MasterCaseNumber.Contains(query));
                
            var clientDto = clientsQuery.ToList().Select(Mapper.Map<Client, ClientDto>);

            return Ok(clientDto);
        }





        // GET /api/Clients/1
        [HttpGet]
        public IHttpActionResult GetClient(int id)
        {
            var client = _context.Clients.SingleOrDefault(c => c.Id == id);

            if (client == null)
                return NotFound();

            return Ok(Mapper.Map<Client, ClientDto>(client));
        }


        // POST /api/Clients
        [HttpPost]
        public IHttpActionResult CreateClient(ClientDto guardianDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var client = Mapper.Map<ClientDto, Client>(guardianDto);
            _context.Clients.Add(client);
            _context.SaveChanges();

            guardianDto.Id = client.Id;

            return Created(new Uri(Request.RequestUri + "/" + client.Id), guardianDto);
        }


        // PUT /api/Clients/1
        [HttpPut]
        public IHttpActionResult UpdateClient(int id,ClientDto clientDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var clientInDb = _context.Clients.SingleOrDefault(c => c.Id == id);

            if (clientInDb == null)
                NotFound();

            Mapper.Map(clientDto, clientInDb);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/Clients/1
        [HttpDelete]
        public IHttpActionResult ToggleClient(int id)
        {
            var clientInDb = _context.Clients.SingleOrDefault(c => c.Id == id);

            if (clientInDb == null)
                return NotFound();

            if (clientInDb.IsEnabled == true)
                clientInDb.IsEnabled = false;
            else
                clientInDb.IsEnabled = true;

            _context.SaveChanges();

            return Ok();
        }


    }

}

