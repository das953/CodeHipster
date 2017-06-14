using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeHipser.Models.Dtos
{
    public class LessonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public int ParentId { get; set; }
        public CategoryDto Parent { get; set; }
    }
}
