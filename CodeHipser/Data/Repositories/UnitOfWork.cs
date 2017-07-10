using CodeHipser.Data.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeHipser.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Sections = new SectionsEFRepository(_context);
            SectionTypes = new SectionTypesEFRepository(_context);
        }
        public ISectionsRepository Sections { get; private set; }

        public ISectionTypesRepository SectionTypes { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
