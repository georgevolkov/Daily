using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Questionnaire.Service.Interfaces;
using Questionnaire.Web.Controllers.Base;
using Questionnaire.Web.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Questionnaire.Web.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IMapper mapper, IAnswerService answerService, UserManager<User> userManager)
            : base(mapper, answerService, userManager) { }

        public IActionResult Index(string query)
        {
            ViewBag.SearchQuery = (query ?? "");
            
            return View();
        }

        // method to getting data to scrolling page
        public async Task<JsonResult> GetData(int pageNumber, string query, int sort)
        {
            var pageSize = 20;
            var models = await GetData(pageSize, pageNumber, sort, query);


            return Json(new { models.Data, total = models.RecordsTotal, filtered = models.RecordsFiltered });
        }
        
        [Authorize]
        public IActionResult Answer()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Answer(AnswerViewModel model)
        {
            if (ModelState.IsValid)
            {
                var currentUser = await _userManager.GetUserAsync(HttpContext.User);
                model.Answer.UserId = Guid.Parse(currentUser.Id);

                await _answerService.AddAnswerAsync(model.Answer);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> About(string answerId)
        {
            var answer = await _answerService.GetAnswerByIdAsync(Guid.Parse(answerId));
            var viewModel = new AnswerViewModel
            {
                Answer = answer
            };
            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
