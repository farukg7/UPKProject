using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IRepositoryManager
    {
        IHammaddeRepository Hammadde { get; }
        IKategoriRepository Kategori { get; }
        IProjeRepository Proje { get; }
        IUrunRepository Urun { get; }
        ISiparisRepository Siparis { get; }
        IHammaddeSiparisRepository HammaddeSiparis { get; }
        IUrunSiparisRepository UrunSiparis { get; }
        IAtolyeRepository Atolye { get; }
        IRotaRepository Rota { get; }
        IAtolyeIslerRepository AtolyeIsler { get; }
        IPlanlamaRepository Planlama { get; }
        ITedarikciRepository Tedarikci { get; }
        IMusteriRepository Musteri { get; }
        void Save();
    }
}
