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

namespace CodeHipser.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/Categories")]
    public class CategoriesController : Controller
    {
        private ApplicationDbContext _context;
        public CategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IEnumerable<CategoryDto> GetCategories()
        {
            IEnumerable<Section> categories = _context?.Sections?.Where(x => x.SectionTypeId == SectionType.Category)?.OrderBy(x => x.Name).GetHierarchy(x => x.ParentId == null).ToList();
            List<CategoryDto> categoryDtos = new List<CategoryDto>();
            foreach (var item in categories)
            {
                if (item.ParentId == null)
                    categoryDtos.Add(MapSectionToCategoryDto(item));
            }
            return categoryDtos;
        }

        private CategoryDto MapSectionToCategoryDto(Section section)
        {
            CategoryDto category = new CategoryDto
            {
                Id = section.Id,
                Name = section.Name,
                Children = new List<CategoryDto>()
            };
            foreach (var item in section.Children)
            {
                category.Children.Add(MapSectionToCategoryDto(item));
            }
            return category;
        }
    }
}