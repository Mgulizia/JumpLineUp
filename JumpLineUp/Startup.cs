﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JumpLineUp.Startup))]
namespace JumpLineUp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
