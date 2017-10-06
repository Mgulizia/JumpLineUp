﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JumpLineUp.Models
{
    public class SupportService
    {

        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string MasterCaseNumber { get; set; }

        public string AuthorizationNumber { get; set; }

        public DateTime? ServiceStart { get; set; }

        public DateTime? ServiceStop { get; set; }


        public Client Clients { get; set; }
        public int ClientIds { get; set; }

        public List<YouthInService> YouthInServices { get; set; }
        public List<int> YouthInServicesId { get; set; }

        public ServiceArea ServiceArea { get; set; }
        public int ServiceAreaId { get; set; }

        public ServiceType ServiceType { get; set; }
        public int ServiceTypeId { get; set; }

        public CfsWorker CfsWorker { get; set; }
        public int CfsWorkerId { get; set; }

        public bool OnHold { get; set; }

    }
}