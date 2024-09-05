using LapStore.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LapStore.Areas.admin.Controllers
{
    [Area("admin")]
    public class HomeController : Controller
    {
        [Authorize(Roles ="Admin")]
        [Auhorization]
        public IActionResult Index()
        {
            return View();
        }
    }
}
