using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JumpLineUp.Models;

namespace JumpLineUp.ViewModels.SupportServices
{
    public class SupportServicesViewModel
    {
        public SupportService SupportServices { get; set; }
        public List<ServiceArea> ServiceAreas { get; set; }
        public List<Models.ServiceType> ServiceTypes { get; set; }
    }
}