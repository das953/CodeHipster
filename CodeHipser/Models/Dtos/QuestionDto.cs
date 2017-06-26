using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodeHipser.Models.Dtos
{
    public class QuestionDto
    {
        public int Id { get; set; }

        [Required]
        public string QuestionText { get; set; }

        [Required]
        public int CorrectAnswerId { get; set; }

        public List<AnswerDto> Answers { get; set; }

        public QuestionDto()
        {
            Answers = new List<AnswerDto>();
        }
    }
}
