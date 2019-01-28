using Jhuri.Models.Admin;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Jhuri.Models
{
    public class ApplicationUsers: IdentityUser
    {

        public string Name { get; set; }
        public string Contact { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string JoinIp { get; set; }
        public string Address { get; set; }
        public int? CityId { get; set; }
        public string Refference { get; set; }

        [ForeignKey("CityId")]
        public virtual City City { get; set; }
        public virtual ICollection<ProductComments> ProductCommentses { get; set; }
        public virtual ICollection<Orders> Orderses { get; set; }
        public virtual ICollection<OrderStatus> OrderStatuses { get; set; }
    }
}
