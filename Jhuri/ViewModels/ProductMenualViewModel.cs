using Jhuri.Data;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Jhuri.ViewModels
{
    public class ProductMenualViewModel : BaseEntity
    {
        [Display(Name ="Product")]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public IFormFile ProductFile { get; set; }
        public string ManualName { get; set; }
    }
}
