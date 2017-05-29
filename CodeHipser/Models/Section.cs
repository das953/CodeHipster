using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeHipser.Models.EntityBase;

namespace CodeHipser.Models
{
    public class Section : RecursiveEntity<Section>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Number { get; set; }
        public string Content { get; set; }

        public int CourseId { get; set; }
        public virtual Course Course { get; set; }

        public int SectionTypeId { get; set; }
        public virtual SectionType SectionType { get; set; }

        public virtual ICollection<StudentProgress> StudentProgress { get; set; }
    }
}
