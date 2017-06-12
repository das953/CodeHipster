using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CodeHipser.Models;
using CodeHipser.Data;
using Microsoft.EntityFrameworkCore;

namespace CodeHipser.Controllers
{
    public class CourseController : Controller
    {
        private ApplicationDbContext _context;
        public CourseController(ApplicationDbContext context)
        {
            _context = context;
        }
        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
        public IActionResult Index(int id)
        {
            //var course = _context?.Courses?.Include(s => s.Sections)?.SingleOrDefault(x => x.Id == id);
            return View();
        }
        public IActionResult CourseDetails(int id)
        {
            Section section = _context?.Sections?.Include(c=>c.Children)?.SingleOrDefault(x => x.Id == id);
            return PartialView(section);
        }
    }
}