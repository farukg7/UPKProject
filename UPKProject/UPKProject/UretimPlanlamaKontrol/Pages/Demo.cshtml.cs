using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UretimPlanlamaKontrol.Pages
{
    public class DemoModel : PageModel
    {
        public String? FullName => HttpContext.Session?.GetString("name") ?? "";  //ba�ta bu yap�y� constructor olu�turup tan�mlam��t�k o haliyle sessiondaki bilgiyi html sayfam�zda okuyamamam��t�k


        public void OnGet()
        {
        }

        public void OnPost([FromForm]string name) 
        {
            //FullName = name;
            //oturum bilgisini sessiondan alaca��m i�in ilgili alan� tan�ml�yorum
            HttpContext.Session.SetString("name", name); 
        }
    }
}
