using CodeHipser.Data.Repositories.Abstract;
using CodeHipser.Models;
using CodeHipser.Models.EntityBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeHipser.Data.Repositories
{
    public class SectionsEFRepository : EFRecursiveRepository<Section>, ISectionsRepository
    {
        public SectionsEFRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<Section> GetOrderedSections()
        {
            IEnumerable<Section> hierarchy = Context.Sections.Include(x => x.Children).Include(x => x.SectionType).ToList();
            IEnumerable<Section> rootHierarchy = hierarchy.Where(x => x.ParentId == null).OrderHierarchyBy(x => x.Name).ToList();
            return rootHierarchy.FlattenHierarchy();
        }

        public Section GetSectionByIdIncluded(int id)
        {
            return Context.Sections.Include(x => x.Children).Include(x => x.SectionType).Include(x => x.Parent).Include(x => x.Questions).ThenInclude(x => x.Answers).SingleOrDefault(x => x.Id == id);
        }

        public Section GetSectionByIdParentIncluded(int id)
        {
            return Context.Sections.Include(x => x.Parent).SingleOrDefault(x => x.Id == id);
        }
    }
}
