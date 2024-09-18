using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UretimPlanlamaKontrol.Areas.Yonetici.Controllers
{
    [Area("Yonetici")]
    [Authorize(Roles = "Yonetici")]//action bazlı da gerçekleştirilebilirdi araya virgül atarak diğer kullanıcıların da erişmesine izin verebilirdik
    public class DashboardController:Controller
    {
        
        public IActionResult Index()
        {
            TempData["info"] = $"Welcome back, {DateTime.Now.ToShortTimeString()}";
            return View();
        }
    }
}
