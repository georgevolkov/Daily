using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Daily.Service.Interfaces;
using Daily.Web.Controllers.Base;
using Daily.Web.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Daily.Web.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        public HomeController(IMapper mapper, IDailyService answerService, UserManager<User> userManager)
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
            var models = await GetData(pageSize, pageNumber, query);


            return Json(new { models.Data, total = models.RecordsTotal, filtered = models.RecordsFiltered });
        }
        
        public IActionResult Daily()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Daily(DailyViewModel model)
        {
            if (ModelState.IsValid)
            {
                var currentUser = await _userManager.GetUserAsync(HttpContext.User);
                model.Daily.UserId = Guid.Parse(currentUser.Id);

                await _dailyService.AddDailyAsync(model.Daily);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> About(string dailyId)
        {
            var daily = await _dailyService.GetDailyByIdAsync(Guid.Parse(dailyId));
            var viewModel = new DailyViewModel
            {
                Daily = daily
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
