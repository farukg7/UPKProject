using Entities.Models;
using Entities.RequestParameters;
using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;
using Services.Contracts;
using UretimPlanlamaKontrol.Models;
using UretimPlanlamaKontrol.Repositories;

namespace UretimPlanlamaKontrol.Controllers
{
    public class HammaddeController : Controller
    {
        private readonly IServiceManager _manager;

        public HammaddeController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index(HammaddeRequestParameters p)
        {
            var hammaddeler = _manager.HammaddeService.GetAllHammaddelerWithDetails(p);
            var pagination = new Pagination()
            {
                CurrentPage = p.PageNumber,
                ItemsPerPage = p.PageSize,
                TotalItems = _manager.HammaddeService.GetAllHammadeler(false).Count()
        };
            return View(new HammaddeListViewModel()
            {
                Hammaddeler=hammaddeler,
                Pagination=pagination,
            });
        }

        public IActionResult Get([FromRoute(Name ="id")] int id)
        {
            var model = _manager.HammaddeService.GetOneHammadde(id, false);
            return View(model);
        }
    }
}
