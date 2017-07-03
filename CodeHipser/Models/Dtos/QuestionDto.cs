using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodeHipser.Models.Dtos
{
    public class QuestionDto
    {
        private readonly int _minAnswers = 4;
        private readonly int _maxAnswers = 6;

        public int Id { get; set; }

        [Required]
        [Display(Name = "question")]
        public string QuestionText { get; set; }

        [Required]
        [Display(Name = "correct answer")]
        public int? CorrectAnswerId { get; set; }
        public List<AnswerDto> Answers { get; set; }

        public int MinAnswers { get { return _minAnswers; } }
        public int MaxAnswers { get { return _maxAnswers; } }

        public QuestionDto()
        {
            Answers = new List<AnswerDto>();
        }
    }
}
