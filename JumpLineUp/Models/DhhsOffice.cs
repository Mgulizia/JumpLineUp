﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JumpLineUp.Models
{
    public class DhhsOffice
    {
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