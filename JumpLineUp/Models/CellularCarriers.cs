using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JumpLineUp.Models
{
    public class CellularCarriers
    {
        public static readonly byte Verizon = 1;
        public static readonly byte UsCellular = 2;
        public static readonly byte Sprint = 3;
        public static readonly byte Att = 4;
        public static readonly byte Tmobile = 5;
        public static readonly byte StraightTalk = 6;
        public static readonly byte Viaero = 7;
        public static readonly byte Cricket = 8;

        public int Id { get; set; }
        public string CarrierName { get; set; }
        public string CarrierExtension { get; set; }

    }
}