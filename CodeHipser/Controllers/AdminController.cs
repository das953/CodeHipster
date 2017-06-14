using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CodeHipser.Data;
using CodeHipser.Models;
using Microsoft.EntityFrameworkCore;
using CodeHipser.Models.EntityBase;

namespace CodeHipser.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext _context;
        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Section> hierarchy = _context?.Sections?.Include(x=>x.Children).OrderHierarchyBy(x=>x.Name).ToList();
            IEnumerable<Section> rootHierarchy = hierarchy.Where(x => x.ParentId == null).ToList();
            return View(rootHierarchy);
        }
    }
}