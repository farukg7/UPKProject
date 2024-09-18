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

        public Plan Plan { get; set; }  //IoC planýn içinde hangi bilgi varsa onu da ongete getireceðiz bunun içinde IoC kaydý yapacaðýz(kullanýcý bazýnda sepetlerin ayrý ayrý tutulmasýný saðlayacaðýz) 

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

        public IActionResult OnPost(int Id, string returnUrl)   //hangi id ye sahip veya ürünler sepete eklendi bunu plan sayfasýna post edeceðiz ayný zamanda sayfa bilgisini hafýzaya almak istediðimiz için returnurl parametresini projeye ekledik
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
