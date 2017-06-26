using AutoMapper;
using CodeHipser.Models;
using CodeHipser.Models.Dtos;
using CodeHipser.ViewModels;
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
            CreateMap<Section, SectionDto>().PreserveReferences();
            CreateMap<Question, QuestionDto>().PreserveReferences();
            CreateMap<Answer, AnswerDto>().PreserveReferences();
            CreateMap<SectionType, SectionTypeDto>().PreserveReferences();

            CreateMap<QuestionDto, Question>().PreserveReferences();
            CreateMap<AnswerDto, Answer>().PreserveReferences();
            CreateMap<SectionDto, Section>().ForMember(x=>x.SectionType, opt=>opt.Ignore()).PreserveReferences();
            CreateMap<SectionTypeDto, SectionType>();
        }
    }
}
