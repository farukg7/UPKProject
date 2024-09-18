using AutoMapper;
using Entities.Models;
using Entities.Models.ViewModel;
using Repositories;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UretimPlanlamaKontrol.Repositories;

namespace Services
{
    public class UrunManager : IUrunService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public UrunManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public void CreateOneUrun(Urun urun)
        {
            _manager.Urun.CreateOneUrun(urun);
            _manager.Save();
        }

        public List<Urun> GetAllUrunByNotNullUrunSiparis(bool trackChanges)
        {
           return _manager.Urun.GetAllUrunByNotNullUrunSiparis(trackChanges);
        }

        public IEnumerable<Urun> GetAllUrunler(bool trackChanges)
        {
           return _manager.Urun.GetAllUrunler(trackChanges);
        }

        public UrunHammaddeViewModel? GetMaxIdUrunForHammadde(bool trackChanges)
        {
            var urun = _manager.Urun.GetMaxIdUrun(trackChanges);
            if (urun == null)
            {
                throw new Exception("Aradığınız ürün bulunamadı");
            }
            var mapurun = _mapper.Map<UrunHammaddeViewModel>(urun);
            return mapurun;

            //return _manager.Urun.GetMaxIdUrun(trackChanges);
        }

        public UrunRotaViewModel? GetMaxIdUrunForRota(bool trackChanges)
        {
            var urun = _manager.Urun.GetMaxIdUrun(trackChanges);
            if (urun == null)
            {
                throw new Exception("Aradığınız ürün bulunamadı");
            }
            var mapurun = _mapper.Map<UrunRotaViewModel>(urun);
            return mapurun;
        }

        public Urun? GetOneUrun(int id, bool trackChanges)
        {
            Urun urun=_manager.Urun.GetOneUrun(id, trackChanges);
            if(urun == null)
            {
                throw new Exception("Aradığınız ürün bulunamadı.");
            }
            return urun;
        }

        public void UpdateOneUrun(Urun urun)
        {
            _manager.Urun.UpdateOneUrun(urun);
            _manager.Save();
        }
    }
}
