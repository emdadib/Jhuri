using Jhuri.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jhuri.ViewModels
{
    public class StatusViewModel : BaseEntity
    {
        public string Name { get; set; }
        public string Level { get; set; }
        public string Description { get; set; }
    }
}
