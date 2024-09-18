using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace UretimPlanlamaKontrol.Areas.Yonetici.Controllers
{
    [Area("Yonetici")]
    [Authorize(Roles = "Yonetici")]//action bazlı da gerçekleştirilebilirdi araya virgül atarak diğer kullanıcıların da erişmesine izin verebilirdik
    public class SiparisController : Controller
    {
        private readonly IServiceManager _manager;

        public SiparisController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            var orders = _manager.SiparisService.Siparisler;
            return View(orders);
        }

        [HttpPost]
        public IActionResult Complete([FromForm] int id)
        {
            _manager.SiparisService.Tamamla(id);
            return RedirectToAction("Index");
        }
    }
}
