using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CodeHipser.Controllers
{
    public class SectionsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}