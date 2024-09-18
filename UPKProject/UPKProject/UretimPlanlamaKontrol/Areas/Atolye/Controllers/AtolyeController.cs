using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace UretimPlanlamaKontrol.Areas.Atolye.Controllers
{
    [Area("Atolye")]
    public class AtolyeController : Controller
    {
        private readonly IServiceManager _manager;

        public AtolyeController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            var model= _manager.AtolyeService.GetAllAtolyeler(false);
            return View(model);
        }

        public IActionResult Get([FromRoute(Name ="id")] int id)
        {
            var model=_manager.AtolyeService.GetOneAtolye(id,false);
            return View(model);
        }
    }
}
