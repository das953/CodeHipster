using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CodeHipser.Data;
using AutoMapper;
using CodeHipser.Models.Dtos;
using CodeHipser.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeHipser.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/Lessons")]
    public class LessonsController : Controller
    {
        private ApplicationDbContext _context;
        private IMapper _mapper;

        //Settings of IMapper in file MappingProfile (project root folder)
        public LessonsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        public LessonDto GetLessonById(int? id)
        {
            Section lesson = _context.Sections.Include(x => x.SectionType).SingleOrDefault(x => x.Id == id);
            if (lesson == null || lesson.SectionType.ParentId != SectionType.Course)
                NotFound();
            LessonDto lessonDto = _mapper.Map<LessonDto>(lesson);

            return lessonDto;
        }
    }
}