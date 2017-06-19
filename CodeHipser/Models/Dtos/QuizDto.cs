using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeHipser.Models.Dtos
{
    public class QuizDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int ParentId { get; set; }
        public CategoryDto Parent { get; set; }

        public virtual ICollection<QuestionDto> Questions { get; set; }

        public QuizDto()
        {
            Questions = new List<QuestionDto>();
        }

    }
}
