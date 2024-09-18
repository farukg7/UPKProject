using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UretimPlanlamaKontrol.Repositories;

namespace Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly IHammaddeRepository _hammadderepository;
        private readonly IKategoriRepository _kategorirepository;
        private readonly IUrunRepository _urunrepository;
        private readonly IProjeRepository _projeRepository;
        private readonly ISiparisRepository _siparisrepository;
        private readonly IHammaddeSiparisRepository _hammaddesiparisrepository;
        private readonly IUrunSiparisRepository _urunsiparisrepository;
        private readonly IAtolyeRepository _atolyerepository;
        private readonly IRotaRepository _rotarepository;
        private readonly IAtolyeIslerRepository _atolyeislerrepository;
        private readonly IPlanlamaRepository _planlamarepository;
        private readonly ITedarikciRepository _tedarikcirepository;
        private readonly IMusteriRepository _musterirepository;

        public RepositoryManager(IHammaddeRepository repository, RepositoryContext context, IKategoriRepository kategorirepository, IUrunRepository urunrepository, IProjeRepository projeRepository, ISiparisRepository siparisrepository, IHammaddeSiparisRepository hammaddeSiparisRepository, IUrunSiparisRepository urunsiparisrepository, IAtolyeRepository atolyerepository, IRotaRepository rotarepository, IAtolyeIslerRepository atolyeislerrepository, IPlanlamaRepository planlamarepository, ITedarikciRepository tedarikcirepository, IMusteriRepository musterirepository)
        {
            _hammadderepository = repository;
            _context = context;
            _kategorirepository = kategorirepository;
            _urunrepository = urunrepository;
            _projeRepository = projeRepository;
            _siparisrepository = siparisrepository;
            _hammaddesiparisrepository = hammaddeSiparisRepository;
            _urunsiparisrepository = urunsiparisrepository;
            _atolyerepository = atolyerepository;
            _rotarepository = rotarepository;
            _atolyeislerrepository = atolyeislerrepository;
            _planlamarepository = planlamarepository;
            _tedarikcirepository = tedarikcirepository;
            _musterirepository = musterirepository;
        }

        public IHammaddeRepository Hammadde => _hammadderepository;

        public IKategoriRepository Kategori => _kategorirepository;

        public IUrunRepository Urun => _urunrepository;

        public IProjeRepository Proje => _projeRepository;

        public ISiparisRepository Siparis => _siparisrepository;

        public IHammaddeSiparisRepository HammaddeSiparis=> _hammaddesiparisrepository;

        public IUrunSiparisRepository UrunSiparis => _urunsiparisrepository;

        public IAtolyeRepository Atolye => _atolyerepository;

        public IRotaRepository Rota => _rotarepository;

        public IAtolyeIslerRepository AtolyeIsler => _atolyeislerrepository;

        public IPlanlamaRepository Planlama => _planlamarepository;

        public ITedarikciRepository Tedarikci => _tedarikcirepository;

        public IMusteriRepository Musteri => _musterirepository;

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
