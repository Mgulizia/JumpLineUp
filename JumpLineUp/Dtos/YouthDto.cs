using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using JumpLineUp.Models;

namespace JumpLineUp.Dtos
{
    public class YouthDto
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        public string YouthComment { get; set; }

        public bool IsEnabled { get; set; }

        //Relational Properties
        public int? RestraintTypeId { get; set; }
    }
}