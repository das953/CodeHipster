using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CodeHipser.Data;
using CodeHipser.Models;
using Microsoft.EntityFrameworkCore;
using CodeHipser.Models.EntityBase;
using CodeHipser.ViewModels;

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
            IEnumerable<Section> hierarchy = _context.Sections.Include(x => x.Children).Include(x=>x.SectionType).ToList();
            IEnumerable<Section> rootHierarchy = hierarchy.Where(x => x.ParentId == null).OrderHierarchyBy(x => x.Name).ToList();
            return View(rootHierarchy.FlattenHierarchy());
        }

        /*----------------------------------Root Category--------------------------------*/
        public IActionResult NewCategory(int? id)
        {
            List<SectionType> sectionTypes = new List<SectionType>();
            if (id == null)
            {
                SectionType sectionType = _context.SectionTypes.SingleOrDefault(x => x.Id == SectionType.Category);
                sectionTypes.Add(sectionType);
            }
            else
            {
                Section parentSection = _context.Sections.SingleOrDefault(x => x.Id == id);
                if (parentSection == null)
                    return NotFound();
                sectionTypes = _context.SectionTypes.Where(x => x.ParentId == parentSection.SectionTypeId).ToList();
                if(parentSection?.SectionTypeId==SectionType.Category)
                    sectionTypes.Add(_context.SectionTypes.SingleOrDefault(x => x.Id == SectionType.Category));
            }
            CategoryFormViewModel viewModel = new CategoryFormViewModel
            {
                Section = new Section { ParentId = id},
                SectionTypes = sectionTypes
            };
            return View(viewModel);
        }

        //[HttpPost]
        //public IActionResult NewCategory(CategoryFormViewModel viewModel)
        //{
        //    if(!ModelState.IsValid)
        //    {
        //        Section empty = new Section();
        //        return View("NewCategory", empty);
        //    }
        //    if (viewModel.Category.Id == 0)
        //        _context.Sections.Add(viewModel.Category);
        //        _context.SaveChanges();
        //    return RedirectToAction("Index", "Admin");
        //}

        [HttpPost]
        public IActionResult NewCategory([FromForm]Section section)
        {
            if (!ModelState.IsValid)
            {
                Section empty = new Section();
                return View("NewCategory", empty);
            }
            if (section.Id == 0)
                _context.Sections.Add(section);
            _context.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }

        /*-----------------------------Sub Category (category or course)-------------------------*/
    }
}