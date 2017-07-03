﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CodeHipser.Models;
using CodeHipser.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using CodeHipser.Models.Dtos;

namespace CodeHipser.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public HomeController(
            ApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
         
        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult Quiz(int ID)
        {
            
            ViewData["Greeting"] = "Hello";
            ViewData["Message"] = "Try to pass this quiz, Good luck :)";
            var _currentQuiz = GetQuiz(ID);
            //quizDTO.Questions.FirstOrDefault()
            return ViewComponent("QuizQuestion", "Some");
        }

        public QuizDto GetQuiz(int? id = null)
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
                quizDto.Questions.Add(question);
            }
            return quizDto;
        }
    }
}
