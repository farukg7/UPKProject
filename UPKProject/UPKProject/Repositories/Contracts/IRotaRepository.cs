using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IRotaRepository:IRepositoryBase<Rota>
    {
        IQueryable<Rota> GetRotasByUrun(int id, bool trackChanges);
        Rota? GetOneUrunByRota(int id,bool trackChanges);
        Rota? FindUrunAndRota(int urunId, int atolyeId, bool trackChanges);
        Rota? NextRota(int id, bool trackChanges);
        void UpdateRotas(IEnumerable<Rota> Rotalar);
        void CreateRota(Rota rota);
    }
}
