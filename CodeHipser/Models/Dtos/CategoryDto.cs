﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeHipser.Models.Dtos
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<CategoryDto> Children { get; set; }

        public CategoryDto()
        {
            Children = new List<CategoryDto>();
        }
    }
}
