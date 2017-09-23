using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Http.ModelBinding;

namespace JumpLineUp.Models
{
    public class CfsWorker
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Text needs to be between 3 and 40 characters")]
        [MaxLength(40, ErrorMessage = "Text needs to be between 3 and 40 characters")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Text needs to be between 3 and 40 characters")]
        [MaxLength(40, ErrorMessage = "Text needs to be between 3 and 40 characters")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Phone]
        [MinLength(10,ErrorMessage = "Phone number must contain an area code.")]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Text needs to be between 3 and 50 characters")]
        [MaxLength(50, ErrorMessage = "Text needs to be between 3 and 50 characters")]
        [Display(Name = "Office Location")]
        public string OfficeLocation { get; set; }

        public bool IsActive { get; set; }

        public string FormatPhone()
        {
            return Helpers.Phone.DisplayPhone(this.Phone);
        }
    }
}