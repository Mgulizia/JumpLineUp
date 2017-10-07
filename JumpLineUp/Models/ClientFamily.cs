using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JumpLineUp.Models
{
    public class ClientFamily
    {
        public int Id { get; set; }

        public Client PrimaryClient { get; set; }
        public int PrimaryClientId { get; set; }

        public Client SecondaryClient { get; set; }
        public int SecondaryClientId { get; set; }

        public List<Youth> Youths { get; set; }
        public List<int> YouthsId { get; set; }

    }
}