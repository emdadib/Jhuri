using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jhuri.ViewModels.Public
{
    public class AddToCartViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double FinalPrice { get; set; }
    }
}
