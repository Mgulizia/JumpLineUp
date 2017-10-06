using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using JumpLineUp.Models;

namespace JumpLineUp.Dtos
{
    public class SupportServiceDto
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string MasterCaseNumber { get; set; }

        public string AuthorizationNumber { get; set; }

        public DateTime? ServiceStart { get; set; }

        public DateTime? ServiceStop { get; set; }


        public List<Client> Clients { get; set; }
        public List<int> ClientIds { get; set; }

        public List<Youth> Youths { get; set; }
        public List<int> YouthIds { get; set; }

        public ServiceArea ServiceArea { get; set; }
        public int ServiceAreaId { get; set; }

        public ServiceType ServiceType { get; set; }
        public int ServiceTypeId { get; set; }

        public CfsWorker CfsWorker { get; set; }
        public int CfsWorkerId { get; set; }

        public bool OnHold { get; set; }
    }
}