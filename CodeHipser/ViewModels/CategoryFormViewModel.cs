using CodeHipser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeHipser.ViewModels
{
    public class CategoryFormViewModel
    {
        public Section Section { get; set; }
        public List<SectionType> SectionTypes { get; set; }
    }
}
