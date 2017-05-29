using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeHipser.Models.EntityBase;

namespace CodeHipser.Models
{
    public class StudentProgress
    {
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public int SectionId { get; set; }
        public virtual Section Section { get; set; }

        public bool Completed { get; set; }
    }
}
