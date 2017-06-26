using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeHipser.Models.EntityBase;
using System.ComponentModel.DataAnnotations;

namespace CodeHipser.Models
{
    public class Question : Entity
    {
        [Required]
        public string QuestionText { get; set; }
        public int QuestionGrade { get; set; }

        public int SectionId { get; set; }
        public virtual Section Section { get; set; }

        public Question()
        {
            Answers = new List<Answer>();
        }
        public virtual IList<Answer> Answers { get; set; }
    }
}
