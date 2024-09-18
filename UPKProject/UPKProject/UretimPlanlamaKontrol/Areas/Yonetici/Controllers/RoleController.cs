using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace UretimPlanlamaKontrol.Areas.Yonetici.Controllers
{
    [Area("Yonetici")]
    [Authorize(Roles = "Yonetici")]//action bazlı da gerçekleştirilebilirdi araya virgül atarak diğer kullanıcıların da erişmesine izin verebilirdik
    public class RoleController : Controller
    {
        private readonly IServiceManager _manager;

        public RoleController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            return View(_manager.AuthService.Roles);
        }
    }
}
