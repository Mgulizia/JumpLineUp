using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace JumpLineUp.Models
{
    public class ServiceType
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Service Abbreviation")]
        public string ServiceAbbrieviation { get; set; }

        [Required]
        [Display(Name = "Service Name")]
        public string ServiceName { get; set; }

        [Required]
        [Display(Name = "Service/Billing Code")]
        public int ServiceCode { get; set; }

        [Display(Name = "Current BLCS Service")]
        public bool CurrentService { get; set; }
    }

}