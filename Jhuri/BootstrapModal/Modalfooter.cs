using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jhuri.BootstrapModal
{
    public class Modalfooter
    {
        public string SubmitButtonText { get; set; } = "Submit";
        public string CancelButtonText { get; set; } = "Cancel";
        public string SubmitButtonID { get; set; } = "submit";
        public string CancelButtonID { get; set; } = "cancel";
        public bool OnlyCancelButton { get; set; } 
    }
}
