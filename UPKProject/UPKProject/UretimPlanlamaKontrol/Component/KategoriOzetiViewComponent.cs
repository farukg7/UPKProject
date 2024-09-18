using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace UretimPlanlamaKontrol.Component
{
    public class KategoriOzetiViewComponent:ViewComponent
    {
        private readonly IServiceManager _manager;

        public KategoriOzetiViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }

        public string Invoke()
        {
            return _manager.KategoriService.GetAllKategoriler(false).Count().ToString();
        }
    }
}
