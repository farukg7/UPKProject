using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Contracts;
using UretimPlanlamaKontrol.Infrastructure.Extensions;

namespace UretimPlanlamaKontrol.Pages
{
    public class PlanModel : PageModel
    {
        private readonly IServiceManager _manager;

        public Plan Plan { get; set; }  //IoC plan�n i�inde hangi bilgi varsa onu da ongete getirece�iz bunun i�inde IoC kayd� yapaca��z(kullan�c� baz�nda sepetlerin ayr� ayr� tutulmas�n� sa�layaca��z) 

        public string ReturnUrl { get; set; } = "/";

        public PlanModel(IServiceManager manager, Plan planService)
        {
            _manager = manager;
            Plan =planService;
        }
      

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
           // Plan = HttpContext.Session.GetJson<Plan>("plan") ?? new Plan();
        }

        public IActionResult OnPost(int Id, string returnUrl)   //hangi id ye sahip veya �r�nler sepete eklendi bunu plan sayfas�na post edece�iz ayn� zamanda sayfa bilgisini haf�zaya almak istedi�imiz i�in returnurl parametresini projeye ekledik
        {
            Hammadde? hammadde = _manager.HammaddeService.GetOneHammadde(Id, false);
            if(hammadde is not null)
            {
                //Plan = HttpContext.Session.GetJson<Plan>("plan") ?? new Plan();
                Plan.HammaddeEkle(hammadde, 1);
                //HttpContext.Session.SetJson<Plan>("plan",Plan);
            }
            return RedirectToPage(new {returnUrl=returnUrl});  //returnUrl
        }     

        public IActionResult OnPostRemove(int id, string removeUrl)
        {
            //Plan = HttpContext.Session.GetJson<Plan>("plan") ?? new Plan();
            Plan.HammaddeCikar(Plan.Lines.First(cl => cl.Hammadde.HammaddeId.Equals(id)).Hammadde);
            //HttpContext.Session.SetJson<Plan>("plan", Plan);
            return Page();
        }
    }
}
