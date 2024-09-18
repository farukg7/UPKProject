using Entities.Dtos;
using Entities.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Contracts;
using Newtonsoft.Json;
using AutoMapper;
using Entities.Models;

namespace UretimPlanlamaKontrol.Areas.Proje.Controllers
{
    [Area("Proje")]
    public class ProjeController : Controller
    {
        private readonly IServiceManager _manager;
        private readonly IMapper _mapper;

        public ProjeController(IServiceManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var model = _manager.UrunService.GetAllUrunler(false);
            return View(model);
        }

        public IActionResult CreateUrun(Urun urun)
        {
            ViewBag.Projeler = GetProjeSelectList();
            return View(urun);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUrun([FromForm] Urun urun, IFormFile file)
        {
            if (file != null)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                urun.UrunResimUrl = String.Concat("/images/", file.FileName);
            }
                           
            _manager.UrunService.CreateOneUrun(urun);

             return RedirectToAction("SelectHammaddeForUrun");           
        }

        public IActionResult SelectHammaddeForUrun()
        {
            var urunHammaddeViewModel = _manager.UrunService.GetMaxIdUrunForHammadde(false);
            if (urunHammaddeViewModel == null)
            {
                return NotFound("Son eklenen ürün bulunamadı.");
            }

            ViewBag.Hammaddeler = GetHammaddeSelectList();
            return View(urunHammaddeViewModel); 
        }

        [HttpPost]
        public IActionResult SelectHammaddeForUrunPost(UrunHammaddeViewModel urunHammaddeViewModel)
        {
            var urunid = _manager.UrunService.GetMaxIdUrunForHammadde(false);

            if (urunHammaddeViewModel == null || urunHammaddeViewModel.Hammaddeler == null || urunHammaddeViewModel.Hammaddeler.Count == 0)
            {
                return BadRequest("Geçersiz veri.");
            }

            foreach (var hammadde in urunHammaddeViewModel.Hammaddeler)
            {
                var existingHammadde = _manager.HammaddeService.GetOneHammadde(hammadde.HammaddeId, false);

                if (existingHammadde != null)
                {
                    existingHammadde.KullanimMiktari = hammadde.KullanimMiktari;
                    existingHammadde.UrunId = urunid.UrunId;

                    _manager.HammaddeService.UpdateOneHammaddeUrun(existingHammadde);
                }
                else
                {
                    return NotFound($"Hammadde with ID {hammadde.HammaddeId} not found.");
                }
            }

            return RedirectToAction("SelectRotaForUrun");
        }

        public IActionResult SelectRotaForUrun()
        {
            var maxidurun = _manager.UrunService.GetMaxIdUrunForRota(false);
            if (maxidurun == null)
            {
                return NotFound("Son eklenen ürün bulunamadı.");
            }

            ViewBag.Atolyeler = GetAtolyeSelectList();
            return View(maxidurun);
        }

        [HttpPost]
        public IActionResult SelectRotaForUrunPost(UrunRotaViewModel urunRotaVm)
        {
            var urun = _manager.UrunService.GetMaxIdUrunForRota(false);

            if (urunRotaVm == null || urunRotaVm.Rotalar == null || urunRotaVm.Rotalar.Count == 0)
            {
                return BadRequest("Geçersiz veri.");
            }

            foreach (var rota in urunRotaVm.Rotalar)
            {
                var existingAtolye = _manager.AtolyeService.GetOneAtolyeForRota(rota.AtolyeId, false);

                if (existingAtolye != null)
                {
                    var yeniRota = new Rota
                    {
                        AtolyeId = rota.AtolyeId,
                        UrunId = urun.UrunId,
                        IslemSure = rota.IslemSure,
                        IslemSırası = rota.IslemSırası
                    };

                    _manager.RotaService.CreateRota(yeniRota);
                }
                else
                {
                    return NotFound($"Hammadde with ID {urunRotaVm.AtolyeId} not found.");
                }
            }

            return RedirectToAction("Index", "Proje");

        }

        private SelectList GetProjeSelectList()
        {
            return new SelectList(_manager.ProjeService.GetAllProjeler(false), "ProjeId", "ProjeAdi", "1");
        }

        private SelectList GetHammaddeSelectList()
        {
            return new SelectList(_manager.HammaddeService.GetAllHammadeler(false), "HammaddeId", "Adi", "1");
        }

        private SelectList GetAtolyeSelectList()
        {
            return new SelectList(_manager.AtolyeService.GetAllAtolyeler(false), "AtolyeId", "AtolyeAdi", "1");
        }
    }
}
