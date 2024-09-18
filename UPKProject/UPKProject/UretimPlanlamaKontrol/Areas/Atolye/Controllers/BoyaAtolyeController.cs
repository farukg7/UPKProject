using AutoMapper;
using Entities.Models;
using Entities.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace UretimPlanlamaKontrol.Areas.Atolye.Controllers
{
    [Area("Atolye")]
    public class BoyaAtolyeController : Controller
    {
        private readonly IServiceManager _manager;
        private readonly IMapper _mapper;

        public BoyaAtolyeController(IServiceManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var model = _manager.AtolyeIslerService.GetBoyaAtolye();
            var viewmodel=_mapper.Map<IEnumerable<AtolyeIslerViewModel>>(model);
            if (viewmodel == null)
            {
                return View("Error");
            }
            return View(viewmodel);
        }

        [HttpPost]
        public IActionResult SonrakiIstasyon([FromForm] int urnid, int atlid)
        {
            var urunrota = _manager.RotaService.FindUrunAndRota(urnid, atlid, false);
            

            int rotabelirtec = urunrota.IslemSırası + 1;

            var nextrota = _manager.RotaService.NextRota(rotabelirtec, false);

            if (nextrota == null)
            {
                var urun = _manager.UrunService.GetOneUrun(urnid, false);
                urun.UrunMiktari += 1;
                _manager.UrunService.UpdateOneUrun(urun);
                var siparis = _manager.UrunSiparisService.GetOneUrunSiparis(urnid, false);
                siparis.UrunTeslimMiktari += 1;
                _manager.UrunSiparisService.UpdateUrunSiparis(siparis);
                return View("SuccessMessage", "Tebrikler ürün üretildi.");
            }

            var rotaveurun = _manager.AtolyeIslerService.GetOneAtolyeIslerByUrunIdAndAtolyeId(nextrota.UrunId, nextrota.AtolyeId, true);

            var eksilecekurun = _manager.AtolyeIslerService.GetOneAtolyeIslerByUrunIdAndAtolyeId(urnid, atlid, false);
            eksilecekurun.UrunMiktari -= 1;
            _manager.AtolyeIslerService.UpdateOneAtolyeIs(eksilecekurun);


            if (rotaveurun != null)
            {
                rotaveurun.UrunMiktari += 1;
                _manager.AtolyeIslerService.UpdateOneAtolyeIs(rotaveurun);
            }
            else
            {
                var atolyeIsler = new AtolyeIsler
                {
                    AtolyeId = nextrota.AtolyeId,
                    UrunId = nextrota.UrunId,
                    UrunMiktari = 1
                };
                _manager.AtolyeIslerService.CreateOneAtolyeIs(atolyeIsler);
            }

            return RedirectToAction("Index");
        }
    }
}
