using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JumpLineUp.Dtos
{
    public class CfsWorkerDto
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Text needs to be between 3 and 40 characters")]
        [MaxLength(40, ErrorMessage = "Text needs to be between 3 and 40 characters")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Text needs to be between 3 and 40 characters")]
        [MaxLength(40, ErrorMessage = "Text needs to be between 3 and 40 characters")]
        public string LastName { get; set; }

        [Required]
        [Phone]
        [MinLength(10, ErrorMessage = "Phone number must contain an area code.")]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Text needs to be between 3 and 50 characters")]
        [MaxLength(50, ErrorMessage = "Text needs to be between 3 and 50 characters")]
        public string OfficeLocation { get; set; }

        public bool IsActive { get; set; }
    }
}