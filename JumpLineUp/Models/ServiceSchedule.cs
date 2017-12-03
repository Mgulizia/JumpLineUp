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

        [Required]
        [Display(Name = "Schedule End Date")]
        public DateTime ScheduleEndDate { get; set; }

        [Display(Name = "Pick Up Details")]
        public string PickupDetails { get; set; }

        [Required]
        [Display(Name = "Visit Location")]
        public string VisitationLocation { get; set; }

        [Display(Name = "Drop Off Location")]
        public string DropOffLocation { get; set; }

        [Display(Name = "Visit Restrictions")]
        public string Restrictions { get; set; }

        public bool IsEnabled { get; set; }

        public bool CurrentSchedule { get; set; }

        // ---- RELATED MODELS -----------------------------------------------------

        public SupportService SupportService { get; set; }
        public int? SupportServiceId { get; set; }


        // ------------------------------- SUNDAY ----------------------------------

        [DefaultValue(false)]
        public bool Sunday { get; set; }

        [Display(Name = "Session Start")]
        public DateTime? SunStartTime { get; set; }

        [Display(Name = "Session Duration")]
        public byte? SunDuration { get; set; }
        

        // ------------------------------- MONDAY ----------------------------------

        [DefaultValue(false)]
        public bool Monday { get; set; }

        [Display(Name = "Session Start")]
        public DateTime? MonStartTime { get; set; }

        [Display(Name = "Session Duration")]
        public byte? MonDuration { get; set; }

        // ------------------------------- TUESDAY ----------------------------------

        [DefaultValue(false)]
        public bool Tuesday { get; set; }

        [Display(Name = "Session Start")]
        public DateTime? TueStartTime { get; set; }

        [Display(Name = "Session Duration")]
        public byte? TueDuration { get; set; }

        // ------------------------------- WEDNESDAY ---------------------------------

        [DefaultValue(false)]
        public bool Wednesday { get; set; }

        [Display(Name = "Session Start")]
        public DateTime? WedStartTime { get; set; }

        [Display(Name = "Session Duration")]
        public byte? WedDuration { get; set; }

        // ------------------------------- THURSDAY ----------------------------------

        [DefaultValue(false)]
        public bool Thursday { get; set; }

        [Display(Name = "Session Start")]
        public DateTime? ThurStartTime { get; set; }

        [Display(Name = "Session Duration")]
        public byte? ThurDuration { get; set; }

        // ------------------------------- FRIDAY ------------------------------------

        [DefaultValue(false)]
        public bool Friday { get; set; }

        [Display(Name = "Session Start")]
        public DateTime? FriStartTime { get; set; }

        [Display(Name = "Session Duration")]
        public byte? FriDuration { get; set; }

        // ------------------------------- SATRUDAY ----------------------------------

        [DefaultValue(false)]
        public bool Saturday { get; set; }

        [Display(Name = "Session Start")]
        public DateTime? SatStartTime { get; set; }

        [Display(Name = "Session Duration")]
        public byte? SatDuration { get; set; }




    }
}