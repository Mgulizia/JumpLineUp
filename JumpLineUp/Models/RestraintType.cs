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

        //Save context information from database into selectable properties.
        public static readonly byte Unknown = 0;
        public static readonly byte Infant = 1;
        public static readonly byte HighBackBoosterSeat = 2;
        public static readonly byte BoosterSeat = 3;
        public static readonly byte FivePointFrontFacing = 4;
        public static readonly byte FivePointRearFacing = 5;
    }
    

}