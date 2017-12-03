using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JumpLineUp.Models;

namespace JumpLineUp.ViewModels.SupportServices
{
    public class SupportServiceDetailViewModel
    {
        public SupportService SupportServices { get; set; }
        public ServiceSchedule ServiceSchedule { get; set; }    
    }
}