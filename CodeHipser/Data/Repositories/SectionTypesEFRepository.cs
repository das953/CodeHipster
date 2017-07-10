using CodeHipser.Data.Repositories.Abstract;
using CodeHipser.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeHipser.Data.Repositories
{
    public class SectionTypesEFRepository : EFRepository<SectionType>, ISectionTypesRepository
    {
        public SectionTypesEFRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
