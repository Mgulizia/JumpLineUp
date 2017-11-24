using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JumpLineUp.Models
{
    public class OtherContact
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }

       
        [MinLength(3)]
        [Display(Name = "Street Address")]
        public string Street1 { get; set; }

        [Display(Name = "Address Suffix")]
        public string Street2 { get; set; }

        
        [MinLength(3)]
        public string City { get; set; }

       
        [StringLength(2)]
        public string State { get; set; }

        
        [StringLength(5)]
        public string Zip { get; set; }

        public bool IsEnabled { get; set; }

        public List<SupportService> SupportServices { get; set; }
        public List<int> SupportServicesId { get; set; }

    }
}