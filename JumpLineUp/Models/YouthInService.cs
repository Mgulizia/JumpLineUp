using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JumpLineUp.Models
{
    public class YouthInService
    {
        public int Id { get; set; }

        public Youth Youth { get; set; }
        [Required]
        public int YouthId { get; set; }

        public SupportService SupportService { get; set; }
        [Required]
        public int SupportServiceId { get; set; }
    }
}