using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodeHipser.Models.Dtos
{
    public class SectionDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string VideoUrl { get; set; }
        public int? ParentId { get; set; }
        public SectionDto Parent { get; set; }

        [Required]
        public int SectionTypeId { get; set; }
        public SectionTypeDto SectionType { get; set; }

        public List<SectionDto> Children { get; set; }
        public List<QuestionDto> Questions { get; set; }

        public SectionDto()
        {
            Children = new List<SectionDto>();
            Questions = new List<QuestionDto>();
        }
    }
}
