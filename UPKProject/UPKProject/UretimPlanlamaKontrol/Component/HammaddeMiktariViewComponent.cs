using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using UretimPlanlamaKontrol.Repositories;

namespace UretimPlanlamaKontrol.Component
{
    //burada serviste tanımladığımız metotlarıda kullanabiliriz
    public class HammaddeMiktariViewComponent:ViewComponent
    {
        private readonly IServiceManager _manager; 

        public HammaddeMiktariViewComponent(IServiceManager context)
        {
            _manager = context;
        }

        public string Invoke()
        {
            return _manager.HammaddeService.GetAllHammadeler(false).Count().ToString();
        }
    }
}
