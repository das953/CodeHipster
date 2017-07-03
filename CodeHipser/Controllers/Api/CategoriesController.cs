using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CodeHipser.Data;
using CodeHipser.Models;
using CodeHipser.Models.Dtos;
using CodeHipser.Models.EntityBase;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace CodeHipser.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/Categories")]
    public class CategoriesController : Controller
    {
        private ApplicationDbContext _context;
        private readonly IMapper _mapper;

        //Settings of IMapper in file MappingProfile (project root folder)
        public CategoriesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //Get all sections of type Category including their children (Courses)
        //Received JSON used for sidebar menu of categories and courses
        [HttpGet]
        public IEnumerable<CategoryDto> GetCategories()
        {
            
            IEnumerable<Section> categories = _context.Sections.Include(x => x.Children).Where(x => x.SectionTypeId == SectionType.Category).ToList();
            IEnumerable<Section> rootCategories = categories.Where(x => x.ParentId == null).OrderHierarchyBy(x => x.Name).ToList();

            //Get root categoryDtos
            List<CategoryDto> rootCategoryDtos = new List<CategoryDto>();
            foreach (var category in rootCategories)
            {
                rootCategoryDtos.Add(_mapper.Map<CategoryDto>(category));
            }
            return rootCategoryDtos;
        }

        //Get all lessons of the course with id parameter
        //Received JSON used for sidebar menu of themes, lessons, content and quizes
        [HttpGet("{id}")]
        //[Authorize]
        public IEnumerable<CategoryDto> GetCourseById(int? id)
        {
            Section course = _context.Sections.Include(x => x.SectionType).SingleOrDefault(x => x.Id == id);
            if (course == null || course.SectionTypeId != SectionType.Course)
                NotFound();

            IEnumerable<Section> lessons = _context.Sections.Include(x=>x.SectionType).Include(x => x.Children).ToList();
            IEnumerable<Section> rootLessons = lessons?.Where(x => x.ParentId == id).OrderHierarchyBy(x => x.Name).ToList();

            //Get root lessonDtos
            List<CategoryDto> lessonDtos = new List<CategoryDto>();
            foreach (var lesson in rootLessons)
            {
                lessonDtos.Add(_mapper.Map<CategoryDto>(lesson));
            }
            return lessonDtos;
        }
    }
}