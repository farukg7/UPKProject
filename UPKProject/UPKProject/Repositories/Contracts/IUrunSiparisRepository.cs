using Entities.Models;
using Entities.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IUrunSiparisRepository:IRepositoryBase<UrunSiparis>
    {
        IQueryable<UrunSiparis> GetAllUrunSiparis(bool trackChanges);
        List<UrunSiparis> GetAllUrunSiparisByUrun(int id,bool trackChanges);
        UrunSiparis GetOneUrunSiparis(int id,bool trackChanges);  
        void UpdateOneUrunSiparis(UrunSiparis urunSiparis);
        void CreateOneUrunSiparis(UrunSiparis urunSiparis);
    }
}
