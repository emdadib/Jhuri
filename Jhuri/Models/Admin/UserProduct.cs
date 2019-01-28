using Jhuri.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jhuri.Models.Admin
{
   public class UserProduct : BaseEntity
   {
            public string UserId { get; set; }
            public int ProductId { get; set; }
            public ApplicationUsers Users { get; set; }
            public Product Product { get; set; }
   }
    
}
