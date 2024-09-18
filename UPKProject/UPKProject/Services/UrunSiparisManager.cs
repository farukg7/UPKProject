using AutoMapper;
using Entities.Models;
using Entities.Models.ViewModel;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UrunSiparisManager : IUrunSiparisService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public UrunSiparisManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public void CreateUrunSiparis(UrunSiparisViewModel urunSiparisVM)
        {
            var model=_mapper.Map<UrunSiparis>(urunSiparisVM);
            _manager.UrunSiparis.CreateOneUrunSiparis(model);
            _manager.Save();
        }

        public IQueryable<UrunSiparis> GetAllUrunSiparisler(bool trackChanges)
        {
            return _manager.UrunSiparis.GetAllUrunSiparis(trackChanges).Include(u=>u.Urun).ThenInclude(u=>u.Proje).Include(u => u.Urun).ThenInclude(u => u.Rotalar);
        }

        public UrunSiparis GetOneUrunSiparis(int id, bool trackChanges)
        {
            return _manager.UrunSiparis.GetOneUrunSiparis(id, trackChanges);
        }

        public void UpdateUrunSiparis(UrunSiparis urunSiparis)
        {
            _manager.UrunSiparis.Update(urunSiparis);
            _manager.Save();
        }
    }
}
