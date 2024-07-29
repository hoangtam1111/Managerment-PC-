using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebPC.Identity
{
    public class AppUser:IdentityUser
    {
        public string Name {  get; set; }
        public string DiaChi { get; set; }
    }
}