using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using CodeHipser.Models;

namespace CodeHipser.ViewComponents
{
    [ViewComponent]
    public class QuizQuestionViewComponent : ViewComponent
    {
        //глянути
        //paging VC 
        //view state
        //msvs go to all

        //public IViewComponentResult InvokeAsync(
        //    Question currentQuestion, 
        //    int currentCount, 
        //    int totalCount,
        //    string themeName)
              public Task<IViewComponentResult> InvokeAsync(
            string themeName)
        {
            //ViewData["currentCount"] = currentCount;
            //ViewData["totalCount"] = totalCount;
            //ViewData["themeName"] = themeName;
            //return (IViewComponentResult)View("Default", currentQuestion);

            ViewData["currentCount"] = 1;
            ViewData["totalCount"] = 10;
            ViewData["themeName"] = themeName;
            return Task.FromResult<IViewComponentResult>(View("Default", new Question { Id = 4}));

        }
    }
}
