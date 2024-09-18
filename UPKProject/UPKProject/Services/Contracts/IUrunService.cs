using Entities.Models;
using Entities.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IUrunService
    {
        List<Urun> GetAllUrunByNotNullUrunSiparis(bool trackChanges);
        IEnumerable<Urun> GetAllUrunler(bool trackChanges);
        Urun? GetOneUrun(int id, bool trackChanges);
        UrunHammaddeViewModel? GetMaxIdUrunForHammadde(bool trackChanges);
        UrunRotaViewModel? GetMaxIdUrunForRota(bool trackChanges);
        void UpdateOneUrun(Urun urun);
        void CreateOneUrun(Urun urun);
    }
}
