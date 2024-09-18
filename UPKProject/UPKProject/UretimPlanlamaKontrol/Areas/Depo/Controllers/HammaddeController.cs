using Entities.RequestParameters;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using UretimPlanlamaKontrol.Models;

namespace UretimPlanlamaKontrol.Areas.Depo.Controllers
{
    [Area("Depo")]
    public class HammaddeController : Controller
    {

        private readonly IServiceManager _manager;

        public HammaddeController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index(HammaddeRequestParameters p)
        {
            var hammaddeler=_manager.HammaddeService.GetAllHammaddelerWithDetails(p);
            var pagination = new Pagination()
            {
                CurrentPage = p.PageNumber,
                ItemsPerPage = p.PageSize,
                TotalItems = _manager.HammaddeService.GetAllHammadeler(false).Count()
            };
            return View(new HammaddeListViewModel()
            {
                Hammaddeler = hammaddeler,
                Pagination = pagination
            });
        }
    }
}
