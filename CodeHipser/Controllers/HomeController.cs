using System;
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
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
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
            var _currentQuiz = RedirectToAction($@"/api/Quiz/"+ID);
            //quizDTO.Questions.FirstOrDefault()
            return View();
        }
    }
}
