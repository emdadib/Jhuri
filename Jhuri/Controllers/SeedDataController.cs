using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Jhuri.Controllers
{
    public class SeedDataController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}