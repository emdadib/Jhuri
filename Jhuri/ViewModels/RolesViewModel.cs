using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Jhuri.ViewModels
{
    public class RolesViewModel
    {
        public string Id { get; set; }
        [Required] 
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public string IpAddress { get; set; }
    }

    public class RolesListViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumberOfUser { get; set; }
  
    }
}
