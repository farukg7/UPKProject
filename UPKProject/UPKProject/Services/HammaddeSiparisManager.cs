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
    public class HammaddeSiparisManager : IHammaddeSiparisService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public HammaddeSiparisManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public void CreateHammaddeSiparis(HammaddeSiparisViewModel siparis)
        {
            var hammaddeSiparis = _mapper.Map<HammaddeSiparis>(siparis);
            _manager.HammaddeSiparis.CreateHammaddeSiparis(hammaddeSiparis);
            _manager.Save();
        }

        public IEnumerable<HammaddeSiparisViewModel> GetAllHammaddeSiparis(bool trackChanges)
        {
            var hammaddeSiparisList = _manager.HammaddeSiparis.GetAllHammadeSiparisler(trackChanges)
                .Select(s => new HammaddeSiparisViewModel
                {
                    HammaddeSiparisId=s.HammaddeSiparisId,
                    HammaddeAdi = s.Hammadde.HammaddeAdi,
                    TedarikciAdi = s.Tedarikci.TedarikciAdi,
                    HammaddeSiparisAdedi = s.HammaddeSiparisAdedi,
                    HammaddeGelenAdet = s.HammaddeGelenAdet,
                    HammaddeSiparisBirimi = s.HammaddeSiparisBirimi,
                    HammaddeSiparisTarihi = s.HammaddeSiparisTarihi,
                    HammaddeTeslimTarihi = s.HammaddeTeslimTarihi
                }).ToList();

            return hammaddeSiparisList;
        }

        public MalKabulViewModel GetOneHammaddeSiparis(int id, bool trackChanges)
        {
            var model = _manager.HammaddeSiparis.GetHammaddeSiparisById(id, trackChanges);
            var mapModel = _mapper.Map<MalKabulViewModel>(model);
            return mapModel;

        }

        public void MalKabul(int siparisId, int miktar)
        {
            var siparis = _manager.HammaddeSiparis.GetHammaddeSiparisById(siparisId, true);
            if (siparis == null || siparis.Hammadde == null)
            {
                throw new Exception("Hammadde siparişi veya hammadde bulunamadı");
            }

            if (siparis.HammaddeSiparisAdedi < miktar)
            {
                throw new Exception("Girmiş olduğunuz miktar sipariş miktarından fazla olamaz");
            }
            if (siparis.HammaddeSiparisAdedi-siparis.HammaddeGelenAdet < miktar)
            {
                throw new Exception("Gelen hammadde miktarı önceki gelenlerle birlikte sipariş miktarını aşmaktadır");
            }

            siparis.HammaddeGelenAdet += miktar;
            _manager.HammaddeSiparis.UpdateHammaddeSiparis(siparis);    
            

            var hammadde = _manager.Hammadde.GetOneHammadde((int)siparis.HammaddeId, true);
            hammadde.HammaddeMiktari += miktar;
            _manager.Hammadde.Update(hammadde);

            _manager.Save();
        }
    }
}
