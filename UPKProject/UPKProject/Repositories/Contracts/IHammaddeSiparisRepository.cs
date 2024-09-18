using Entities.Models;
using Entities.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IHammaddeSiparisRepository:IRepositoryBase<HammaddeSiparis>
    {
        IQueryable<HammaddeSiparis> GetAllHammadeSiparisler(bool trackChanges);
        List<HammaddeSiparis> GetAllHammaddeSiparislerByUrun(int urunId, bool trackChanges);
        List<HammaddeSiparis> GetAllHammaddeSiparislerByUrunAndSiparisTarihi(int id, bool trackChanges);
        HammaddeSiparis GetHammaddeSiparisById(int id, bool trackChanges);
        void CreateHammaddeSiparis(HammaddeSiparis siparis);
        void UpdateHammaddeSiparis(HammaddeSiparis hammaddeSiparis);
    }
}
