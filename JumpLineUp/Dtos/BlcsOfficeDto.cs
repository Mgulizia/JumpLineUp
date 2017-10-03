using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JumpLineUp.Dtos
{
    public class BlcsOfficeDto
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string LocationDescription { get; set; }

        [Required]
        [StringLength(10)]
        public string Phone { get; set; }

        [Required]
        [MinLength(3)]
        public string Street1 { get; set; }

        public string Street2 { get; set; }

        [Required]
        [MinLength(3)]
        public string City { get; set; }

        [Required]
        [StringLength(2, ErrorMessage = "Abbrieviation only")]
        public string State { get; set; }

        [Required]
        [StringLength(5)]
        public string Zip { get; set; }

        public bool IsEnabled { get; set; }
    }
}