using AutoMapper;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Entities.Models.ViewModel;

namespace UretimPlanlamaKontrol.Areas.Depo.Controllers
{
    [Area("Depo")]
    public class HammaddeSiparisController : Controller
    {
        private readonly IServiceManager _manager;
        private readonly IMapper _mapper;

        public HammaddeSiparisController(IServiceManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var model = _manager.HammaddeSiparisService.GetAllHammaddeSiparis(false).ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult MalKabul(int id)
        {
            var siparis = _manager.HammaddeSiparisService.GetOneHammaddeSiparis(id, true);
            if (siparis == null)
            {
                return NotFound("Hammadde siparişi veya hammadde bulunamadı.");
            }

            var viewModel = new MalKabulViewModel
            {
                HammaddeSiparisId = siparis.HammaddeSiparisId,
                HammaddeAdi = siparis.HammaddeAdi,
                HammaddeSiparisAdedi = siparis?.HammaddeSiparisAdedi ?? 0,
                HammaddeGelenAdet = siparis.HammaddeGelenAdet ?? 0,
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult MalKabul(MalKabulViewModel model)
        {
            if (ModelState.IsValid)
            {   
                var hammaddeSiparis=_mapper.Map<HammaddeSiparis>(model);
                _manager.HammaddeSiparisService.MalKabul(hammaddeSiparis.HammaddeSiparisId, (int)hammaddeSiparis.HammaddeGelenAdet);
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
