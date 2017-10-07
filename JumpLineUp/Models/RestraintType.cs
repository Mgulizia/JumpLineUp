using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JumpLineUp.Models
{
    public class RestraintType
    {
        public int Id { get; set; }
        public string RestraintName { get; set; }

        public List<Youth> YouthNeedingRestraints { get; set; }
        public List<int> YouthNeedingRestraintsId { get; set; }
    }

    public static class RestraintNames
    {
        //Save context information from database into selectable properties
        public const int None = 1;
        public const int HighBackBoosterSeat = 2;
        public const int BoosterSeat = 3;
        public const int FivePointFrontFacing = 4;
        public const int FivePointRearFacing = 5;
    }

}