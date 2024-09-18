using Repositories;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly IHammaddeService _hammaddeService;
        private readonly IKategoriService _kategoriService;
        private readonly IProjeService _projeService;
        private readonly IUrunService _urunService;
        private readonly ISiparisService _siparisService;
        private readonly IAuthService _authService;
        private readonly IHammaddeSiparisService _hammaddeSiparisService;
        private readonly IUrunSiparisService _urunSiparisService;
        private readonly IAtolyeService _atolyeService;
        private readonly IRotaService _rotaService;
        private readonly IAtolyeIslerService _atolyeIslerService;
        private readonly IPlanlamaService _planlamaService;
        private readonly ITedarikciService _tedarikciService;
        private readonly IMusteriService _musteriService;


        public ServiceManager(IHammaddeService hammaddeService, IKategoriService kategoriService, IProjeService projeService, IUrunService urunService, ISiparisService siparisService, IAuthService authService, IHammaddeSiparisService hammaddeSiparisService, IUrunSiparisService urunSiparisService, IAtolyeService atolyeService, IRotaService rotaService, IAtolyeIslerService atolyeIslerService, IPlanlamaService planlamaService, ITedarikciService tedarikciService, IMusteriService musteriService)
        {
            _hammaddeService = hammaddeService;
            _kategoriService = kategoriService;
            _projeService = projeService;
            _urunService = urunService;
            _siparisService = siparisService;
            _authService = authService;
            _hammaddeSiparisService = hammaddeSiparisService;
            _urunSiparisService = urunSiparisService;
            _atolyeService = atolyeService;
            _rotaService = rotaService;
            _atolyeIslerService = atolyeIslerService;
            _planlamaService = planlamaService;
            _tedarikciService = tedarikciService;
            _musteriService = musteriService;
        }

        public IHammaddeService HammaddeService => _hammaddeService;

        public IKategoriService KategoriService => _kategoriService;

        public IUrunService UrunService => _urunService;

        public IProjeService ProjeService => _projeService;

        public ISiparisService SiparisService => _siparisService;

        public IAuthService AuthService => _authService;

        public IHammaddeSiparisService HammaddeSiparisService => _hammaddeSiparisService;

        public IUrunSiparisService UrunSiparisService => _urunSiparisService;

        public IAtolyeService AtolyeService => _atolyeService;

        public IRotaService RotaService => _rotaService;

        public IAtolyeIslerService AtolyeIslerService => _atolyeIslerService;

        public IPlanlamaService PlanlamaService => _planlamaService;

        public ITedarikciService TedarikciService => _tedarikciService;

        public IMusteriService MusteriService => _musteriService;
    }
}
