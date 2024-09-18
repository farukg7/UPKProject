using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace UretimPlanlamaKontrol.Component
{
    public class KategoriMenuViewComponent:ViewComponent
    {
        private readonly IServiceManager _manager;

        public KategoriMenuViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }

        public IViewComponentResult Invoke()
        {
            var model = _manager.KategoriService.GetAllKategoriler(false);
            return View(model);
        }
    }
}
