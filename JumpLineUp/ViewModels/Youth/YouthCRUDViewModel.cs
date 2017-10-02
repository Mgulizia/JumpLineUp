using System.Collections.Generic;
using JumpLineUp.Models;

namespace JumpLineUp.ViewModels.Youth
{
    public class YouthCRUDViewModel
    {
        public Models.Youth Youth { get; set; }
        public List<RestraintType> Restraints { get; set; }
    }
}