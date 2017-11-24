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

        public DateTime ServiceStart { get; set; }

        public DateTime ServiceStop { get; set; }


        public Client Client { get; set; }
        public int ClientId { get; set; }

        public List<Youth> Youth { get; set; }
        public List<int> YouthId { get; set; }

        public List<OtherContact> OtherContacts { get; set; }
        public List<int> OtherContactId { get; set; }

        public ServiceArea ServiceArea { get; set; }
        public int ServiceAreaId { get; set; }

        public ServiceType ServiceType { get; set; }
        public int ServiceTypeId { get; set; }

        public CfsWorker CfsWorker { get; set; }
        public int CfsWorkerId { get; set; }

        public FosterParent FosterParent { get; set; }
        public int? FosterParentId { get; set; }

        public bool OnHold { get; set; }
    }
}