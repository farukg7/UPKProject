using Entities.Models;
using Entities.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IAtolyeService
    {
        IEnumerable<Atolye> GetAllAtolyeler(bool trackChanges);
        Atolye? GetOneAtolye(int id, bool trackChanges);
        UrunRotaViewModel GetOneAtolyeForRota(int id, bool trackChanges);
    }
}
