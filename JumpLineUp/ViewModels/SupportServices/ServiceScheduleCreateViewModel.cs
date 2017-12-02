using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JumpLineUp.Models;

namespace JumpLineUp.ViewModels.SupportServices
{
    public class ServiceScheduleCreateViewModel
    {
        public SupportService SupportService { get; set; }
        public ServiceSchedule ServiceSchedule { get; set; }
        public List<Models.BlcsOffice> BlcsOffices { get; set; }
    }
}