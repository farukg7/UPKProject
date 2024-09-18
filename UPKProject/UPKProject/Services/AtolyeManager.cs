using AutoMapper;
using Entities.Models;
using Entities.Models.ViewModel;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AtolyeManager : IAtolyeService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public AtolyeManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public IEnumerable<Atolye> GetAllAtolyeler(bool trackChanges)
        {
            return _manager.Atolye.GetAllAtolyeler(trackChanges);
        }

        public Atolye? GetOneAtolye(int id, bool trackChanges)
        {
            var atolye=_manager.Atolye.GetOneAtolye(id, trackChanges);
            if (atolye is null)
                throw new Exception("Atolye bulunamadı");
            return atolye;
        }

        public UrunRotaViewModel GetOneAtolyeForRota(int id, bool trackChanges)
        {
            var atolye=_manager.Atolye.GetOneAtolye(id, trackChanges);
            if (atolye is null)
            {
                throw new Exception("Aradığınız atölye bulunamadı");
            }
            var atolyerota=_mapper.Map<UrunRotaViewModel>(atolye);
            return atolyerota;
        }
    }
}
