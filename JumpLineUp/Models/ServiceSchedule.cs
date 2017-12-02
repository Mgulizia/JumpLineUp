using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.VisualBasic.CompilerServices;

namespace JumpLineUp.Models
{
    public class ServiceSchedule
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Schedule Start Date")]
        public DateTime ScheduleStartDate { get; set; }

        [Display(Name = "Pick Up Details")]
        public string PickupDetails { get; set; }

        [Required]
        [Display(Name = "Visit Location")]
        public string VisitationLocation { get; set; }

        [Display(Name = "Drop Off Location")]
        public string DropOffLocation { get; set; }

        [Required]
        public string Restrictions { get; set; }

        public bool IsEnabled { get; set; }

        // ---- RELATED MODELS -----------------------------------------------------

        public SupportService SupportService { get; set; }
        public int? SupportServiceId { get; set; }


        // ------------------------------- SUNDAY ----------------------------------

        [DefaultValue(false)]
        public bool Sunday { get; set; }

        public DateTime? SunStartTime { get; set; }

        public byte? SunDuration { get; set; }
        

        // ------------------------------- MONDAY ----------------------------------

        [DefaultValue(false)]
        public bool Monday { get; set; }

        public DateTime? MonStartTime { get; set; }

        public byte? MonDuration { get; set; }

        // ------------------------------- TUESDAY ----------------------------------

        [DefaultValue(false)]
        public bool Tuesday { get; set; }

        public DateTime? TueStartTime { get; set; }

        public byte? TueDuration { get; set; }

        // ------------------------------- WEDNESDAY ---------------------------------

        [DefaultValue(false)]
        public bool Wednesday { get; set; }

        public DateTime? WedStartTime { get; set; }

        public byte? WedDuration { get; set; }

        // ------------------------------- THURSDAY ----------------------------------

        [DefaultValue(false)]
        public bool Thursday { get; set; }

        public DateTime? ThurStartTime { get; set; }

        public byte? ThurDuration { get; set; }

        // ------------------------------- FRIDAY ------------------------------------

        [DefaultValue(false)]
        public bool Friday { get; set; }

        public DateTime? FriStartTime { get; set; }

        public byte? FriDuration { get; set; }

        // ------------------------------- SATRUDAY ----------------------------------

        [DefaultValue(false)]
        public bool Saturday { get; set; }

        public DateTime? SatStartTime { get; set; }

        public byte? SatDuration { get; set; }




    }
}