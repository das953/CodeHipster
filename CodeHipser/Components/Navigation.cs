using CodeHipser.Data;
using CodeHipser.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeHipser.Components
{
    public class Navigation : ViewComponent
    {
        private ApplicationDbContext _context;
        public Navigation(ApplicationDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke(int? id=null)
        {
            List<Section> sections = _context?.Sections?.Include(c => c.Children)?.Where(x => x.ParentId == id).ToList();
            return View(sections);
        }
    }
}
