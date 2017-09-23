using System.Collections.Generic;
using JumpLineUp.Models;

namespace JumpLineUp.ViewModels.Cfs
{
    public class CfsIndexViewModel
    {

        public List<CfsWorker> EnabledCfsWorkers { get; set; }
        public List<CfsWorker> DisabledCfsWorkers { get; set; }

    }
}