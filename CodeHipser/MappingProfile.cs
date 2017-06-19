using AutoMapper;
using CodeHipser.Models;
using CodeHipser.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeHipser
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Section, CategoryDto>();
            CreateMap<Section, LessonDto>();
            CreateMap<Section, SectionDto>();
            CreateMap<Section, QuizDto>();
            CreateMap<Question, QuestionDto>();
            //CreateMap<>
        }
    }
}
