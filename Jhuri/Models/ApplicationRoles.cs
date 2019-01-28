using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jhuri.Models
{
    public class ApplicationRoles : IdentityRole
    {
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public string IpAddress { get; set; }
    }
}
