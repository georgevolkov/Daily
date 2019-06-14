using Microsoft.AspNetCore.Mvc;

namespace Daily.Web.Controllers
{
    public class DailyController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return
            View();
        }
    }
}