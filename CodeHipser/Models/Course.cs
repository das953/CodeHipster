using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeHipser.Models.EntityBase;

namespace CodeHipser.Models
{
    public class Course : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Teacher { get; set; }

        public Course()
        {
            Sections = new List<Section>();
        }
        public virtual ICollection<Section> Sections { get; set; }
    }
}
