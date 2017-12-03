using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JumpLineUp.Models;

namespace JumpLineUp.ViewModels.SupportServices
{
    public class SupportServiceIndexViewModel
    {
        public List<SupportService> NeedsScheduling { get; set; }
        public List<SupportService> NeedsAssigning { get; set; }
        public List<SupportService> ExpiredServices { get; set; }

    }
}