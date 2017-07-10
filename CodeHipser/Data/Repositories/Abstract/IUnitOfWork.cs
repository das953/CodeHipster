using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeHipser.Data.Repositories.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        ISectionsRepository Sections { get; }
        ISectionTypesRepository SectionTypes { get; }
        int Complete();
    }
}
