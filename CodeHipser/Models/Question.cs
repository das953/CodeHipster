using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeHipser.Models.EntityBase;

namespace CodeHipser.Models
{
    public class Question : Entity
    {
        public string QuestionText { get; set; }
        public int QuestionGrade { get; set; }

        public int SectionId { get; set; }
        public virtual Section Section { get; set; }
    }
}
