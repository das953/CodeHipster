using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeHipser.Models.Dtos
{
    public class SectionTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static readonly int Unknown = 0;
        public static readonly int Category = 1;
        public static readonly int Course = 2;
        public static readonly int Theme = 3;
        public static readonly int Lesson = 4;
        public static readonly int VideoLesson = 5;
        public static readonly int TextLesson = 6;
        public static readonly int Quiz = 7;
    }
}
