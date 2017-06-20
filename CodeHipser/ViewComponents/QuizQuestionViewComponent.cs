using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using CodeHipser.Models;

namespace CodeHipser.ViewComponents
{
    public class QuizQuestionViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(
            Question currentQuestion, 
            int currentCount, 
            int totalCount,
            string themeName)
        {
            ViewData["currentCount"] = currentCount;
            ViewData["totalCount"] = totalCount;
            ViewData["themeName"] = themeName;
            return View(currentQuestion);
           
        }
    }
}
