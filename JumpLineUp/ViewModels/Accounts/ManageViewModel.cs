﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JumpLineUp.Models;

namespace JumpLineUp.ViewModels.Accounts
{
    public class ManageViewModel
    {
        public IEnumerable<ApplicationUser> ApplicationUsers { get; set; }
        
    }
}