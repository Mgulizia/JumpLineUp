using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace JumpLineUp.Models
{
    public class ApplicationRole : IdentityRole
    {

        [NotMapped]
        public bool IsChecked { get; set; }

        public string Description { get; set; }
        
    }
}