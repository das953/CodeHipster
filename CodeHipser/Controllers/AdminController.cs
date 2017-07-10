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
using Microsoft.AspNetCore.Authorization;
using CodeHipser.Data.Repositories;
using CodeHipser.Services;

namespace CodeHipser.Controllers
{
    public class AdminController : Controller
    {
        private IMapper _mapper;
        private AdminService _adminService;

        //Dictionary for mapping SectionType to View
        Dictionary<int, string> _sectionTypeToView; 

        public AdminController(AdminService adminService, IMapper mapper)
        {
            _adminService = adminService;
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
            IEnumerable<CategoryDto> hierarchy = _adminService.GetMenuItems();
            return View(hierarchy);
        }

        //Create new section
        public IActionResult New(int sectionTypeId, int? parentId = null)
        {
            SectionViewModel viewModel = _adminService.CreateSectionViewModel(sectionTypeId, parentId);
            return View(_sectionTypeToView[viewModel.SectionDto.SectionTypeId], viewModel);
        }

        //Edit existing section
        public IActionResult Edit(int id)
        {
            SectionViewModel viewModel = _adminService.EditSectionViewModel(id);
            if (viewModel == null)
                return NotFound();
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
                SectionViewModel sectionViewModel = _adminService.EditInvalidSectionViewModel(viewModel);
                if (sectionViewModel == null)
                    return NotFound();
                return View(_sectionTypeToView[viewModel.SectionDto.SectionTypeId], viewModel);
            }

            if (viewModel.SectionDto.SectionTypeId == SectionType.Quiz)
            {
                foreach (var question in viewModel.SectionDto.Questions)
                {
                    if(question.CorrectAnswerId < question.Answers.Count)
                    {
                        question.Answers[(int)question.CorrectAnswerId].IsCorrect = true;
                        break;
                    }    
                }
            }

            //Create new section
            if (viewModel.SectionDto.Id==0)
            {
                _adminService.AddSection(viewModel.SectionDto);
            }

            //Edit existing section
            else
            {
                _adminService.EditSection(viewModel.SectionDto);
            }
            _adminService.SaveChanges();

            if(viewModel.SectionDto.ParentId==null)
                return RedirectToAction("Index", "Admin");
            return RedirectToAction("Edit", "Admin", new { id = viewModel.SectionDto.ParentId });
        }
    }
}