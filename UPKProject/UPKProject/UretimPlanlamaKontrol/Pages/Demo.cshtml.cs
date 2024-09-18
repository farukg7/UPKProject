using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UretimPlanlamaKontrol.Pages
{
    public class DemoModel : PageModel
    {
        public String? FullName => HttpContext.Session?.GetString("name") ?? "";  //baþta bu yapýyý constructor oluþturup tanýmlamýþtýk o haliyle sessiondaki bilgiyi html sayfamýzda okuyamamamýþtýk


        public void OnGet()
        {
        }

        public void OnPost([FromForm]string name) 
        {
            //FullName = name;
            //oturum bilgisini sessiondan alacaðým için ilgili alaný tanýmlýyorum
            HttpContext.Session.SetString("name", name); 
        }
    }
}
