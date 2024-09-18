using Microsoft.AspNetCore.Mvc;

namespace UretimPlanlamaKontrol.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
