using Entities.Models;
using Entities.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IUrunSiparisService
    {
        IQueryable<UrunSiparis> GetAllUrunSiparisler(bool trackChanges);
        UrunSiparis GetOneUrunSiparis(int id, bool trackChanges);
        void UpdateUrunSiparis(UrunSiparis urunSiparis);
        void CreateUrunSiparis(UrunSiparisViewModel urunSiparisVM);
    }
}
