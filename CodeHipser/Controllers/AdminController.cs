using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using CodeHipser.Data;
using CodeHipser.Models;
using Microsoft.EntityFrameworkCore;
using CodeHipser.Models.EntityBase;
using CodeHipser.ViewModels;
using CodeHipser.Models.Dtos;

namespace CodeHipser.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext _context;
        private IMapper _mapper;

        //Dictionary for mapping SectionType to View
        Dictionary<int, string> _sectionTypeToView; 

        public AdminController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _sectionTypeToView = new Dictionary<int, string>()
            {
                { SectionType.Category, "SectionForm" },
                { SectionType.Course, "SectionForm" },
                { SectionType.Theme, "SectionForm" },
                { SectionType.Lesson, "SectionForm" },
                { SectionType.Unknown, "SectionForm" },
                { SectionType.VideoLesson, "VideoLessonForm" },
                { SectionType.TextLesson, "TextLessonForm" },
                { SectionType.Quiz, "QuizForm" }
            };
        }

        //Get flattened hierarchy of Sections
        public IActionResult Index()
        {
            IEnumerable<Section> hierarchy = _context.Sections.Include(x => x.Children).Include(x => x.SectionType).ToList();
            IEnumerable<Section> rootHierarchy = hierarchy.Where(x => x.ParentId == null).OrderHierarchyBy(x => x.Name).ToList();
            return View(rootHierarchy.FlattenHierarchy());
        }

        //Create new section
        public IActionResult New(int sectionTypeId, int? parentId = null)
        {
            Section parentSection = _context.Sections.Include(x=>x.Parent).SingleOrDefault(x => x.Id == parentId);
            if (parentSection == null)
                NotFound();
            
            SectionViewModel viewModel = new SectionViewModel();

            viewModel.SectionDto.ParentId = parentId;
            var sectionType = _context.SectionTypes.SingleOrDefault(x => x.Id == sectionTypeId);
            viewModel.SectionDto.SectionType = _mapper.Map<SectionTypeDto>(sectionType);
            viewModel.SectionDto.SectionTypeId = sectionTypeId;
            List<Section> parentSections = GetParents(parentSection).ToList();
            viewModel.Parents = _mapper.Map<List<Section>, List<SectionDto>>(parentSections);

            return View(_sectionTypeToView[viewModel.SectionDto.SectionTypeId], viewModel);
        }

        //Edit existing section
        public IActionResult Edit(int id)
        {
            //Find section to edit
            Section section = _context.Sections.Include(x=>x.Children).Include(x=>x.SectionType).Include(x=>x.Parent).Include(x => x.Questions).ThenInclude(x=>x.Answers).SingleOrDefault(x => x.Id == id);
            if (section == null)
                return NotFound();
            if (!_sectionTypeToView.ContainsKey(section.SectionTypeId))
                return NotFound();

            //Necessary for DataTable column (SectionType of children)
            foreach (var item in section.Children)
            {
                item.SectionType = _context.SectionTypes.SingleOrDefault(x => x.Id == item.SectionTypeId);
            }
            SectionViewModel viewModel = new SectionViewModel();
            viewModel.SectionDto = _mapper.Map<SectionDto>(section);

            List<SectionType> parentForSectionTypes = GetAvailableSectionTypes(id).ToList();
            viewModel.ParentForSectionTypes = _mapper.Map<List<SectionType>, List<SectionTypeDto>>(parentForSectionTypes);

            List<Section> parentSections = GetParents(section).ToList();
            viewModel.Parents = _mapper.Map<List<Section>, List<SectionDto>>(parentSections);

            return View(_sectionTypeToView[viewModel.SectionDto.SectionTypeId], viewModel);
        }
        
        //Save section
        [HttpPost]
        public IActionResult Save(SectionViewModel viewModel)
        {
            if (viewModel.SectionDto.SectionTypeId != SectionType.TextLesson)
                ModelState.Remove("SectionDto.Content");
            if (viewModel.SectionDto.SectionTypeId != SectionType.VideoLesson)
                ModelState.Remove("SectionDto.VideoUrl");

            //Return same form
            if (!ModelState.IsValid)
            {
                SectionViewModel sectionViewModel = viewModel;

                //sectionViewModel.SectionTypes = GetAvailableSectionTypes(viewModel.Id).ToList();
                //Section section = _context.Sections.Include(x=>x.Parent).SingleOrDefault(x => x.Id == viewModel.Id);
                //viewModel.Parents = GetParents(section).ToList();
                return View(_sectionTypeToView[viewModel.SectionDto.SectionTypeId], viewModel);
            }

            if (viewModel.SectionDto.SectionTypeId == SectionType.Quiz)
            {
                foreach (var question in viewModel.SectionDto.Questions)
                {
                    if(question.CorrectAnswerId < question.Answers.Count)
                        question.Answers[(int)question.CorrectAnswerId].IsCorrect = true;
                }
            }

            //Create new section
            if (viewModel.SectionDto.Id==0)
            {
                Section section = _mapper.Map<Section>(viewModel.SectionDto);
                //section.Questions = viewModel.Questions;
                _context.Sections.Add(section);
            }
            //Edit existing section
            else
            {
                Section sectionInDb = _context.Sections.Include(x=>x.Children).Include(x=>x.SectionType).Include(x=>x.Questions).SingleOrDefault(x => x.Id == viewModel.SectionDto.Id);
                if (sectionInDb == null)
                    return NotFound();
                _mapper.Map(viewModel.SectionDto, sectionInDb);
            }
            _context.SaveChanges();

            if(viewModel.SectionDto.ParentId==null)
                return RedirectToAction("Index", "Admin");
            return RedirectToAction("Edit", "Admin", new { id = viewModel.SectionDto.ParentId });
        }

        //Methods to get parents of section (for breadcrumbs) and available section types for buttons (Create [SectionsType])
        private IEnumerable<SectionType> GetAvailableSectionTypes(int? parentId)
        {
            List<SectionType> sectionTypes = new List<SectionType>();

            if (parentId == null)
            {
                SectionType sectionType = _context.SectionTypes.SingleOrDefault(x => x.Id == SectionType.Category);
                sectionTypes.Add(sectionType);
            }
            else
            {
                Section parentSection = _context.Sections.SingleOrDefault(x => x.Id == parentId);
                if (parentSection == null)
                    return null;
                sectionTypes = _context.SectionTypes.Where(x => x.ParentId == parentSection.SectionTypeId).ToList();
                if (parentSection?.SectionTypeId == SectionType.Category)
                    sectionTypes.Add(_context.SectionTypes.SingleOrDefault(x => x.Id == SectionType.Category));
            }
            return sectionTypes;
        }

        private IEnumerable<Section> GetParents(Section section)
        {
            if(section!=null)
            {
                Section parent = _context.Sections.SingleOrDefault(x => x.Id == section.ParentId);
                if (parent != null)
                {
                    foreach (var item in GetParents(parent))
                    {
                        yield return item;
                    }
                    yield return parent;
                }
            }
        }
    }
}