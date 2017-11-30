using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JumpLineUp.Models
{
    public class SupportServicesStatus
    {
        public byte Id { get; set; }
        public string StatusDescription { get; set; }

    }

    public static class SupportStatusNames
    {
        public const byte NeedsSchedule = 1;
        public const byte NeedsAssignment = 2;


    }
}