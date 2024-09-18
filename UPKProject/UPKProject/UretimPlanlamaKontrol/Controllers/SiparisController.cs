using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace UretimPlanlamaKontrol.Controllers
{
    public class SiparisController:Controller
    {
        private readonly IServiceManager _manager;

        private readonly Plan _plan;

        public SiparisController(IServiceManager manager, Plan plan)
        {
            _manager = manager;
            _plan = plan;
        }

        [Authorize]     //kullanıcı login olmadan checkout işlemini gerçekleştiremez
        public ViewResult Checkout() => View(new Siparis());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Checkout([FromForm] Siparis siparis)
        {
            if (_plan.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Üzgünüm sepetiniz boş");
            }

            if(ModelState.IsValid)
            {
                siparis.Lines = _plan.Lines.ToArray();
                _manager.SiparisService.SiparisiKaydet(siparis);
                _plan.Temizle();
                return RedirectToPage("/Tamamla", new { SiparisId = siparis.SiparisId });
            }

            else
            {
                return View();
            }
        }

    }
}
