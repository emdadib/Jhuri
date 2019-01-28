using Jhuri.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jhuri.Models.Admin
{
    public class UserLoginHistory : BaseEntity
    {
       
        public string UserId { get; set; }
        public string IpAddress { get; set; }

        public virtual ApplicationUsers Users { get; set; }
    }
}
