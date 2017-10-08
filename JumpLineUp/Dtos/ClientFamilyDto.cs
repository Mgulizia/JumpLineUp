using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JumpLineUp.Models;

namespace JumpLineUp.Dtos
{
    public class ClientFamilyDto
    {

        public int Id { get; set; }
        public int primaryKey { get; set; }
        public int? secondaryKey { get; set; }
        public List<int> selectedyouth { get; set; }
    }
}