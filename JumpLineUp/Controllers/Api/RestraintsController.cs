using System;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using JumpLineUp.Dtos;
using JumpLineUp.Models;

namespace JumpLineUp.Controllers.Api
{
    public class RestraintsController : ApiController
    {
        private ApplicationDbContext _context;

        public RestraintsController()
        {
            _context = new ApplicationDbContext();
        }



        // GET /api/Restraints
        [HttpGet]
        public IHttpActionResult GetRestraints()
        {
            var item = _context.RestraintTypes.ToList().Select(a => new
            {
                id = a.Id,
                value = a.RestraintName
            });

            return Ok(item);
        }
    }

}

