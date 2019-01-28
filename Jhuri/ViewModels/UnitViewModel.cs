using Jhuri.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Jhuri.ViewModels
{
    public class UnitViewModel:BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
    public class UnitListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TotalProducts { get; set; }
    }
}
