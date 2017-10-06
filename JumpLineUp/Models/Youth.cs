using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace JumpLineUp.Models
{
    public class Youth
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
        [DataType(DataType.Date)]
        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Any Additional Comments")]
        public string YouthComment { get; set; }

        [Display(Name = "Current Client")]
        public bool IsEnabled { get; set; }

        //Relational Properties
        public RestraintType RestraintType { get; set; }
        [Display(Name = "Types of Car Restraints Required")]
        public int? RestraintTypeId { get; set; }

        public List<YouthInService> YouthInServices { get; set; }
        public List<int> YouthInServicsId { get; set; }


        //------------------------------------------ Related Helper Methods ------------------------------------

        public int GetAge()
        {
            var now = DateTime.Today;
            var age = now.Year - BirthDate.Year;
            if (now < BirthDate.AddYears(age))
                age--;

            return age;
        }
        
    }
}