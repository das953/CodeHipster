using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using CodeHipser.Models;
using CodeHipser.Models.Dtos;

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
              public Task<IViewComponentResult> InvokeAsync(QuizDto _quiz)
        {
            //ViewData["currentCount"] = currentCount;
            //ViewData["totalCount"] = totalCount;
            //ViewData["themeName"] = themeName;
            //return (IViewComponentResult)View("Default", currentQuestion);

            ViewData["currentCount"] =  TempData.Peek("currentCount");
            ViewData["totalCount"] =  TempData.Peek("totalCount");
            ViewData["themeName"] = "Hello world!";

            return Task.FromResult<IViewComponentResult>(View("Default", _quiz));

        }
    }
}
