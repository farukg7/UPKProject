using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Repositories.Contracts;
using Services.Contracts;
using System.Reflection.Metadata.Ecma335;

namespace UretimPlanlamaKontrol.Controllers
{
    public class KategoriController : Controller
    {
        private readonly IServiceManager _manager;

        public KategoriController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            var model = _manager.KategoriService.GetAllKategoriler(false);
            return View(model);   
        }
    }
}
