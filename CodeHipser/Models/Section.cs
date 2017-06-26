using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeHipser.Models.EntityBase;
using System.ComponentModel.DataAnnotations;

namespace CodeHipser.Models
{
    public class Section : RecursiveEntity<Section>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string VideoUrl { get; set; }
        public int Number { get; set; }

        public int SectionTypeId { get; set; }
        public virtual SectionType SectionType { get; set; }

        public Section()
        {
            Children = new List<Section>();
            Questions = new List<Question>();
            StudentProgress = new List<StudentProgress>();
        }

        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<StudentProgress> StudentProgress { get; set; }
    }
}
