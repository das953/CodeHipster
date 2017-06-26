using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeHipser.Models.EntityBase;
using System.ComponentModel.DataAnnotations;

namespace CodeHipser.Models
{
    public class Answer : Entity
    {
        public string AnswerText { get; set; }
        public bool IsCorrect { get; set; }

        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }
    }
}
