using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace UretimPlanlamaKontrol.Controllers
{
    public class UrunController : Controller
    {
        private readonly IServiceManager _manager;

        public UrunController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            var model=_manager.UrunService.GetAllUrunler(false);
            return View(model);
        }

        public IActionResult Get([FromRoute(Name = "id")] int id)
        {
            var model = _manager.UrunService.GetOneUrun(id, false);
            return View(model);
        }
    }
}
