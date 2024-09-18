using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace UretimPlanlamaKontrol.Component
{
    public class VitrinViewComponent:ViewComponent
    {
        private readonly IServiceManager _manager;

        public VitrinViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }

        public IViewComponentResult Invoke(string page="default")
        {
            var products = _manager.HammaddeService.GetVitrinHamaddeler(false);
            return page.Equals("default")
                   ? View(products)
                   : View("List",products);
        }
    }
}
