using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeHipser.Models.Dtos
{
    public class QuestionDto
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public int QuestionGrade { get; set; }

        public virtual ICollection<AnswerDto> Answers { get; set; }

        public QuestionDto()
        {
            Answers = new List<AnswerDto>();
        }
    }
}
