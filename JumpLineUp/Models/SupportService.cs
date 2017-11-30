using System;
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

        public Client Client { get; set; }
        public int ClientId { get; set; }

        public List<Youth> Youth { get; set; }
        public List<int> YouthId { get; set; }

        public List<OtherContact> OtherContacts { get; set; }
        public List<int> OtherContactId { get; set; }

        public FosterParent FosterParent { get; set; }
        public int? FosterParentId { get; set; }

        public ServiceArea ServiceArea { get; set; }
        public int ServiceAreaId { get; set; }

        public ServiceType ServiceType { get; set; }
        public int ServiceTypeId { get; set; }

        public CfsWorker CfsWorker { get; set; }
        public int CfsWorkerId { get; set; }

        public bool OnHold { get; set; }

        public SupportServicesStatus Status { get; set; }
        public byte StatusId { get; set; }

        public void CheckHoldStatus()
        {
            if (this.ServiceStop < DateTime.Now.AddDays(-1))
            {
                var _context = new ApplicationDbContext();
                var thisInDb = _context.SupportServices.SingleOrDefault(c => c.Id == Id);
                thisInDb.OnHold = true;
                _context.SaveChanges();
            }
            else
            {
                var _context = new ApplicationDbContext();
                var thisInDb = _context.SupportServices.SingleOrDefault(c => c.Id == Id);
                thisInDb.OnHold = false;
                _context.SaveChanges();
            }
        }


    }
}