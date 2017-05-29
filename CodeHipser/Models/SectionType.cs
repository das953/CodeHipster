using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeHipser.Models.EntityBase;

namespace CodeHipser.Models
{
    public class SectionType : RecursiveEntity<SectionType>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
