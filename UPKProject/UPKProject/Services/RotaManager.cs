using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class RotaManager : IRotaService
    {
        private readonly IRepositoryManager _manager;

        public RotaManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public Rota? FindUrunAndRota(int urunId, int atolyeId, bool trackChanges)
        {
            return _manager.Rota.FindUrunAndRota(urunId, atolyeId, trackChanges);
        }

        public IEnumerable<Rota> GetRotasByUrun(int id, bool trackChanges)
        {
            return _manager.Rota.GetRotasByUrun(id, trackChanges).ToList();
        }

        public Rota? GetOneUrunByRota(int id, bool trackChanges)
        {
            return _manager.Rota.GetOneUrunByRota(id, trackChanges);
        }

        public Rota? NextRota(int id, bool trackChanges)
        {
            return _manager.Rota.NextRota(id, trackChanges);
        }

        public void Save()
        {
            _manager.Save();
        }

        public void UpdateRotas(IEnumerable<Rota> rotas)
        {
            _manager.Rota.UpdateRotas(rotas);
            _manager.Save();
        }

        public void CreateRota(Rota rota)
        {
            _manager.Rota.CreateRota(rota);
            _manager.Save();
        }
    }
}
