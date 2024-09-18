using Entities.Models;
using Entities.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IHammaddeSiparisService
    {
        IEnumerable<HammaddeSiparisViewModel> GetAllHammaddeSiparis(bool trackChanges);
        void MalKabul(int siparisId, int miktar);
        MalKabulViewModel GetOneHammaddeSiparis(int siparisId, bool trackChanges);
        void CreateHammaddeSiparis(HammaddeSiparisViewModel siparis);
    }
}
