using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeHipser.Models.Dtos
{
    public class SectionDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }

        public int SectionTypeId { get; set; }
        public SectionTypeDto SectionTypeDto { get; set; }

        public ICollection<SectionDto> Children { get; set; }

        public SectionDto()
        {
            Children = new List<SectionDto>();
            Questions = new List<Question>();
            StudentProgress = new List<StudentProgress>();
        }

        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<StudentProgress> StudentProgress { get; set; }
    }
}
