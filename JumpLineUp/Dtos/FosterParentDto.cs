﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JumpLineUp.Dtos
{
    public class FosterParentDto
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [Display(Name = "Foster Parent First Name")]
        public string FirstName1 { get; set; }

        [Required]
        [MinLength(3)]
        [Display(Name = "Foster Parent Last Name")]
        public string LastName1 { get; set; }


        [Required]
        [StringLength(10)]
        [Display(Name = "Phone Number")]
        public string Phone1 { get; set; }


        [MinLength(3)]
        [Display(Name = "Foster Parent First Name")]
        public string FirstName2 { get; set; }


        [MinLength(3)]
        [Display(Name = "Foster Parent Last Name")]
        public string LastName2 { get; set; }


        [StringLength(10)]
        [Display(Name = "Phone Number")]
        public string Phone2 { get; set; }

        [Required]
        [MinLength(3)]
        public string Street1 { get; set; }

        public string Street2 { get; set; }

        [Required]
        [MinLength(3)]
        public string City { get; set; }

        [Required]
        [StringLength(2)]
        public string State { get; set; }

        [Required]
        [StringLength(5)]
        public string Zip { get; set; }

        public bool IsEnabled { get; set; }
    }
}