using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodeHipser.Models.Dtos
{
    public class AnswerDto
    {
        [Required]
        public string AnswerText { get; set; }
        public bool IsCorrect { get; set; }
        
        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
