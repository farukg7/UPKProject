using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IRotaService
    {
        IEnumerable<Rota> GetRotasByUrun(int id, bool trackChanges);
        Rota? GetOneUrunByRota(int id, bool trackChanges);
        Rota? FindUrunAndRota(int urunId, int atolyeId, bool trackChanges);
        Rota? NextRota(int id, bool trackChanges);
        void Save();
        void UpdateRotas(IEnumerable<Rota> rotas);
        void CreateRota(Rota rota);
    }
}
