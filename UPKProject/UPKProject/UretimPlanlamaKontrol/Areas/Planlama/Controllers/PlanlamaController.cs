using AutoMapper;
using Entities.Models;
using Entities.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Repositories.Contracts;
using Services.Contracts;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace UretimPlanlamaKontrol.Areas.Planlama.Controllers
{
    [Area("Planlama")]
    public class PlanlamaController:Controller
    {
        private readonly IServiceManager _manager;
        private readonly IMapper _mapper;

        public PlanlamaController(IServiceManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var model=_manager.UrunSiparisService.GetAllUrunSiparisler(false).ToList();
            var viewmodel=_mapper.Map<List<UrunSiparisRotaViewModel>>(model);
            return View(viewmodel);
        }

        public IActionResult Hammadde()
        {
            var model = _manager.HammaddeService.GetAllHammaddePlan(false);
            return View(model);
        }

        public IActionResult HammaddeSiparis()
        {
            var model=_manager.HammaddeSiparisService.GetAllHammaddeSiparis(false);
            return View(model);
        }

        public IActionResult GenelOzet()
        {
            var model = _manager.PlanlamaService.GetAllSiparis();
            return View(model);
        }

        public IActionResult HammaddeSiparisOlustur()
        {
            ViewBag.Hammaddeler = GetHammaddeSelectList();
            ViewBag.Tedarikciler = GetTedarikciSelectList();
            return View();
        }

        [HttpPost]
        public IActionResult HammaddeSiparisOlustur(HammaddeSiparisViewModel hammaddeSiparis)
        {
            _manager.HammaddeSiparisService.CreateHammaddeSiparis(hammaddeSiparis);
            return RedirectToAction("HammaddeSiparis");
        }

        public IActionResult UrunSiparisOlustur()
        {
            ViewBag.Urunler = GetUrunSelectList();
            ViewBag.Projeler=GetProjeSelectList();
            ViewBag.Musteriler=GetMusteriSelectList();
            return View();
        }

        [HttpPost]
        public IActionResult UrunSiparisOlustur(UrunSiparisViewModel urunSiparisVM)
        {
            _manager.UrunSiparisService.CreateUrunSiparis(urunSiparisVM);
            return RedirectToAction("Index");
        }

        private SelectList GetProjeSelectList()
        {
            return new SelectList(_manager.ProjeService.GetAllProjeler(false), "ProjeId", "ProjeAdi", 1);
        }

        private SelectList GetUrunSelectList()
        {
            return new SelectList(_manager.UrunService.GetAllUrunler(false), "UrunId", "UrunAdi", 1);
        }

        private SelectList GetHammaddeSelectList()
        {
            return new SelectList(_manager.HammaddeService.GetAllHammadeler(false), "HammaddeId", "HammaddeAdi", 1);
        }

        private SelectList GetTedarikciSelectList()
        {
            return new SelectList(_manager.TedarikciService.GetAllTedarikciler(false), "TedarikciId", "TedarikciAdi", 1);
        }

        private SelectList GetMusteriSelectList()
        {
            return new SelectList(_manager.MusteriService.GetAllMusteriler(false), "MusteriId", "MusteriAdi", 1);
        }

        [HttpGet]
        public IActionResult Plan()
        {
            var model = _manager.PlanlamaService.GetAllPlanlamalar(false);
            return View(model);
        }

        [HttpPost]
        public IActionResult PlanaEkle([FromForm] int id)
        {
            var usid = _manager.UrunSiparisService.GetOneUrunSiparis(id, false);
            if(usid == null)
            {
                throw new Exception("Aradığınız ürün bulunamadı");
            }

            var pid=_manager.PlanlamaService.GetOnePlanlamaByUrunSiparisId(id, false);

            if(pid != null)
            {
                if(usid.UrunSiparisAdedi==pid.UrunMiktari)
                {
                    throw new Exception("Planlanacak üretim miktarı sipariş miktarından fazla olamaz");
                }
                pid.UrunMiktari += 1;
                _manager.PlanlamaService.UpdatePlanlama(pid);
            }
            else
            {
                Entities.Models.Planlama pl = new Entities.Models.Planlama();
                {
                    pl.UrunId = usid.UrunId;
                    pl.UrunMiktari = 1;
                    pl.UrunSiparisId= usid.UrunSiparisId;                 
                }

                _manager.PlanlamaService.CreatePlan(pl);

                var rotas = _manager.RotaService.GetRotasByUrun(usid.UrunId.GetValueOrDefault(), false);
                
                foreach(var rt in rotas)
                {
                    rt.PlanlamaId = pl.PlanlamaId;
                }

                _manager.RotaService.UpdateRotas(rotas);
                                         
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Gonder([FromForm] int id)
        {
            var usid = _manager.UrunSiparisService.GetOneUrunSiparis(id,false);
            if (usid == null)
            {
                throw new Exception("Aradığınız ürün bulunamadı");
            }
            if (usid.UrunSiparisAdedi < 1)
            {
                throw new Exception("Yeterli ürün sipariş adedi yok");
            }

            var hammaddeler = _manager.HammaddeService.GetAllHammaddelerByUrun(id, false);

            if (hammaddeler == null)
            {
                throw new Exception("Aradağınız ürüne ilişkin alt malzeme bulunamadı");
            }


            foreach(Hammadde hmd in hammaddeler)
            {
                if (hmd.HammaddeMiktari < hmd.KullanimMiktari)
                {
                    throw new Exception("Hammadde miktarı yetersiz");
                }
                hmd.HammaddeMiktari -= hmd.KullanimMiktari;
            }

            _manager.HammaddeService.UpdateHammaddeler(hammaddeler);


            var ruid = _manager.RotaService.GetOneUrunByRota(id, false);

            if (ruid == null)
            {
                throw new Exception("Ürün için uygun rota bulunamadı");
            }

            var rotaveurun = _manager.AtolyeIslerService.GetOneAtolyeIslerByUrunIdAndAtolyeId(ruid.UrunId, ruid.AtolyeId, true);

            if ( rotaveurun != null)
            {
                rotaveurun.UrunMiktari += 1;
                _manager.AtolyeIslerService.UpdateOneAtolyeIs(rotaveurun);
            }
            else
            {
                var atolyeIsler = new AtolyeIsler
                {
                    AtolyeId = ruid.AtolyeId,
                    UrunId = ruid.UrunId,
                    UrunMiktari = 1
                };
                _manager.AtolyeIslerService.CreateOneAtolyeIs(atolyeIsler);
            }
                    
            return RedirectToAction("Index");
        }
    }
}
