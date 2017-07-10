using CodeHipser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeHipser.Data.Repositories.Abstract
{
    public interface ISectionsRepository : IRepository<Section>
    {
        IEnumerable<Section> GetOrderedSections();
        Section GetSectionByIdIncluded(int id);
        Section GetSectionByIdParentIncluded(int id);
    }
}
