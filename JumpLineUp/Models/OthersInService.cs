using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JumpLineUp.Models
{
    public class OthersInService
    {
        public int Id { get; set; }

        public OtherContact OtherContact { get; set; }
        [Required]
        public int OtherContactId { get; set; }

        public SupportService SupportService { get; set; }
        [Required]
        public int SupportServiceId { get; set; }
    }
}