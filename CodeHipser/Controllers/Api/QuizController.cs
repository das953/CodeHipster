using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CodeHipser.Models;
using CodeHipser.Models.Dtos;
using AutoMapper;
using CodeHipser.Data;
using Microsoft.EntityFrameworkCore;

namespace CodeHipser.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/Quiz")]
    public class QuizController : Controller
    {

        private ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public QuizController(

            ApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet("{id}")]
        public IActionResult Quiz(int? id=null)
        {

            if (id == null) return null;

            Section quiz = _context.Sections.Include(x => x.SectionType).Include(x => x.Parent).SingleOrDefault(x => x.Id == id);
            
            if (quiz == null || quiz.SectionType.ParentId != SectionType.Theme)
                NotFound();

            QuizDto quizDto = _mapper.Map<QuizDto>(quiz);

            var questions =
                _context.Questions.
                Where(x => x.SectionId == id).
                Include(x => x.Answers);

            foreach (var question in questions)
            {
                quizDto.Questions.Add(_mapper.Map<QuestionDto>(question));
            }     

            return RedirectToAction($@"Quiz", "Home", new { quiz = quizDto });
           // return null;
        }
    }
}