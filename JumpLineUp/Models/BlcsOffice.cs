using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JumpLineUp.Models
{
    public class BlcsOffice
    {
        public static readonly byte Lincoln = 1;
        public static readonly byte Fremont = 2;
        public static readonly byte Columbus = 3;
        public static readonly byte York = 4;
        public static readonly byte Beatrice = 5;
        public static readonly byte NebraskaCity = 6;
        public static readonly byte SiouxCity = 7;


        public int Id { get; set; }
        public string LocationDescription { get; set; }
        public string Phone { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    }
}