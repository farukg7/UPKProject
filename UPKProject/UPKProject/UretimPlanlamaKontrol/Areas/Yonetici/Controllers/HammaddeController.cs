using Entities.Dtos;
using Entities.Models;
using Entities.RequestParameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Contracts;
using UretimPlanlamaKontrol.Models;

namespace UretimPlanlamaKontrol.Areas.Yonetici.Controllers
{
    [Area("Yonetici")]
    //[Authorize(Roles = "Yonetici")]//action bazlı da gerçekleştirilebilirdi araya virgül atarak diğer kullanıcıların da erişmesine izin verebilirdik
    public class HammaddeController:Controller
    {
        private readonly IServiceManager _manager;

        public HammaddeController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index([FromQuery]HammaddeRequestParameters p)
        {
            ViewData["Title"] = "Hammadeler";
            var hammaddeler = _manager.HammaddeService.GetAllHammaddelerWithDetails(p);
            var pagination = new Pagination()
            {
                CurrentPage = p.PageNumber,
                ItemsPerPage = p.PageSize,
                TotalItems = _manager.HammaddeService.GetAllHammadeler(false).Count()
            };
            return View(new HammaddeListViewModel()
            {
                Hammaddeler = hammaddeler,
                Pagination = pagination,
            });
        }

        public IActionResult Create()
        {
            //  1.YONTEM ViewBag.Kategoriler = _manager.KategoriService.GetAllKategoriler(false);

            ViewBag.Kategoriler = GetKategoriSelectList();

            return View();
        }

        private SelectList GetKategoriSelectList()
        {
            return new SelectList(_manager.KategoriService.GetAllKategoriler(false), "KategoriId", "Adi", "1");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] HammaddeDtoForInsertion hammaddeDto, IFormFile file)     //form sayfasında imageurl alanını tutan bir yer olmadığı için metod içerisinde bir parametre tanımında bulunduk
        {
            //if (ModelState.IsValid)
            //{
            //file operation
            string path = Path.Combine(Directory.GetCurrentDirectory(),
                "wwwroot", "images", file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            hammaddeDto.ResimUrl = String.Concat("/images/", file.FileName);
            _manager.HammaddeService.CreateOneHammadde(hammaddeDto);
            TempData["success"] = $"{hammaddeDto.Adi} adlı hammadde oluşturuldu.";
            return RedirectToAction("Index");
        }

        public IActionResult Update([FromRoute(Name ="Id")] int id)
        {
            ViewBag.Kategoriler = GetKategoriSelectList();
            var model = _manager.HammaddeService.GetOneHammaddeForUpdate(id, false);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([FromForm] HammaddeDtoForUpdate hammaddeDto, IFormFile file)    
        {
            //if (ModelState.IsValid)
            //{

            string path = Path.Combine(Directory.GetCurrentDirectory(),
            "wwwroot", "images", file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            hammaddeDto.ResimUrl = String.Concat("/images/", file.FileName);
            _manager.HammaddeService.UpdateOneHammadde(hammaddeDto);
                return RedirectToAction("Index");
            //}
            //return View();
        }

        public IActionResult Delete([FromRoute(Name ="Id")] int id) 
        {
            _manager.HammaddeService.DeleteOneHammadde(id);
            TempData["danger"] = "Seçili hammadde silindi.";
            return RedirectToAction("Index");
        }
    }
}
