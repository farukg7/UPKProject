using Microsoft.AspNetCore.Mvc;

namespace UretimPlanlamaKontrol.Component
{
    public class HammaddeFilterMenuViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            //herhangi bir logic yok sadece bir view üretilmesini istedik ama belki daha sonra filterlarla veya veritabanıyla ilgili kriterleri kullanmak isteyebiliriz diye böyle bir alan kurguladık yoksa partialviewlarla da bu yapıyı halledebilirdik 
            return View();
        }
    }
}
