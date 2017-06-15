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
using CodeHipser.Models.EntityBase;

namespace CodeHipser.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/Admin")]
    public class AdminController : Controller
    {
        private ApplicationDbContext _context;
        private IMapper _mapper;

        public AdminController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //Get all sections of type Category including their children (Courses)
        //Received JSON used for sidebar menu of categories and courses
        [HttpGet]
        public IEnumerable<SectionDto> GetSections()
        {

            IEnumerable<Section> sections = _context.Sections.Include(x => x.Children).ToList();
            IEnumerable<Section> rootSections = sections.Where(x => x.ParentId == null).OrderHierarchyBy(x => x.Name).ToList();
            
            List<SectionDto> rootSectionDtos = new List<SectionDto>();
            foreach (var section in rootSectionDtos)
            {
                rootSectionDtos.Add(_mapper.Map<SectionDto>(section));
            }
            return rootSectionDtos;
        }
    }
}